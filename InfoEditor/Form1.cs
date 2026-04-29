using InfoEditor.EffectInfo;
using InfoEditor.EffectInfo.Data;
using InfoEditor.Global;
using InfoEditor.ObjectInfo;
using InfoEditor.ObjectInfo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InfoEditor
{
    public partial class InfoEditorMain : Form
    {
        #region Class Initiallization
        // EffectInfo
        private EffInfo effi = new EffInfo();
        private OBJECT obj = new OBJECT();
        private Sprite sprite = new Sprite();
        private Particle particle = new Particle();
        private Trace trace = new Trace();
        // ObjectInfo
        private ObjInfo obji = new ObjInfo();
        // Misc
        private FormControls fc = new FormControls();
        private InfoHandling infoHandling = new InfoHandling();
        #endregion       

        // This is stupid, but for now it'll do
        private string opened_with_file_path; 

        #region Startup
        public InfoEditorMain()
        {
            InitializeComponent();
            GlobalValues.FileOpened = false;
            GlobalValues.FileSaved = true;
        }
        public InfoEditorMain(string arg)
        {
            InitializeComponent();
            GlobalValues.FileOpened = false;
            GlobalValues.FileSaved = true;
            GlobalValues.FilePath = arg;
        }

        private void InfoEditorMain_Load(object sender, EventArgs e)
        {
            GlobalValues.CurrentForm = Application.OpenForms[0];
            Thread T = new Thread(() => { 
                MainGrid.ScrollBars = ScrollBars.None;
                MainGrid.SuspendLayout();
                TextureNameGrid.ScrollBars = ScrollBars.None;
                TextureNameGrid.SuspendLayout();

                infoHandling.OpenInfoFile(MainGrid, TextureNameGrid);

                this.Invoke((MethodInvoker)delegate { 
                    MainGrid.ResumeLayout(); MainGrid.ScrollBars = ScrollBars.Both;
                    TextureNameGrid.ResumeLayout(); TextureNameGrid.ScrollBars = ScrollBars.Both;
                } );
            });
            // TEST
            if (GlobalValues.FilePath != null)
            {
                T.Start();
            }              
            
            //if(GlobalValues.FilePath != null)
            //    infoHandling.OpenInfoFile(MainGrid, TextureNameGrid);

            fc.InitializeInfoEditor(GlobalValues.CurrentForm, this);                 
        }
        #endregion

        private void GridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void InfoEditorMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            GlobalValues.FilePath = files[0];
            infoHandling.OpenInfoFile(MainGrid, TextureNameGrid);
            //OpenEffectFile(e);     
        }

        private void InfoEditorMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void OnKeyPress_DataRow(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C && !e.Shift)
            {
                #region Copy Row Data
                if (MainGrid.SelectedRows.Count > 0 || TextureNameGrid.SelectedRows.Count > 0)
                {
                    DataGridViewRow selected_row;
                    StringBuilder sb = new StringBuilder();

                    if (MainGrid.SelectedRows.Count > 0)
                        selected_row = MainGrid.SelectedRows[0];
                    else
                        selected_row = TextureNameGrid.SelectedRows[0];

                    foreach (DataGridViewCell cell in selected_row.Cells)
                    {
                        // Basically remove the \0 at the end so the copying of the string doesn't break
                        // *Cause it did
                        if (cell.Value.GetType() == typeof(string))
                        {
                            StringBuilder dummy_sb = new StringBuilder();
                            string temp = cell.Value.ToString();
                            for (int i = 0; i < temp.Length - 1; i++)
                            {
                                if (temp[i] != '\0')
                                {
                                    dummy_sb.Append(temp[i]);
                                }
                            }
                            temp = dummy_sb.ToString();

                            sb.Append(temp);
                        }
                        else
                            sb.Append(cell.Value.ToString());
                        sb.Append("\\");
                    }

                    if (sb.Length > 0)
                        sb.Length--;

                    Clipboard.SetText(sb.ToString());
                    if (MainGrid.SelectedRows.Count > 0)
                        MainGrid.ClearSelection();
                    else
                        TextureNameGrid.ClearSelection();
                }
                #endregion
            }
            else if (e.Control && e.KeyCode == Keys.V && !e.Shift)
            {
                #region Paste Row Data
                if (MainGrid.SelectedRows.Count > 0 || TextureNameGrid.SelectedRows.Count > 0)
                {
                    DataGridViewRow selected_row;
                    string[] clipboard_data = Clipboard.GetText().Split('\\');                

                    if (MainGrid.SelectedRows.Count > 0)
                        selected_row = MainGrid.SelectedRows[0];
                    else
                        selected_row = TextureNameGrid.SelectedRows[0];

                    switch(GlobalValues.EffectType)
                    {
                        case Defines.EFFECTINFO_OBJECT:
                            if(clipboard_data.Length != 38)
                            {
                                MessageBox.Show("Trying to paste row of the wrong type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            selected_row.Cells[3].Value = clipboard_data[3];               // m_strName
                            selected_row.Cells[4].Value = clipboard_data[4];               // m_strObjectFile
                            selected_row.Cells[5].Value = Convert.ToSingle(clipboard_data[5]);        // m_fScale
                            selected_row.Cells[6].Value = Convert.ToInt32(clipboard_data[6]);         // m_nObjectAniType
                            selected_row.Cells[7].Value = Convert.ToSingle(clipboard_data[7]);        // m_fTextureAniVel
                            selected_row.Cells[8].Value = Convert.ToSingle(clipboard_data[8]);        // m_fObjectAniVel
                            selected_row.Cells[9].Value = Convert.ToSingle(clipboard_data[9]);        // m_fTick
                            selected_row.Cells[10].Value = Convert.ToBoolean(clipboard_data[10]);     // m_bZbufferEnable
                            selected_row.Cells[11].Value = Convert.ToSingle(clipboard_data[11]);      // m_cColor.R
                            selected_row.Cells[12].Value = Convert.ToSingle(clipboard_data[12]);      // m_cColor.G
                            selected_row.Cells[13].Value = Convert.ToSingle(clipboard_data[13]);      // m_cColor.B
                            selected_row.Cells[14].Value = Convert.ToSingle(clipboard_data[14]);      // m_cColor.a
                            selected_row.Cells[15].Value = Convert.ToSingle(clipboard_data[15]);      // m_cColorStep.r
                            selected_row.Cells[16].Value = Convert.ToSingle(clipboard_data[16]);      // m_cColorStep.g
                            selected_row.Cells[17].Value = Convert.ToSingle(clipboard_data[17]);      // m_cColorStep.b
                            selected_row.Cells[18].Value = Convert.ToSingle(clipboard_data[18]);      // m_cColorStep.a
                            selected_row.Cells[19].Value = Convert.ToSingle(clipboard_data[19]);      // m_fColorChangeStartTime
                            selected_row.Cells[20].Value = Convert.ToBoolean(clipboard_data[20]);     // m_bAlphaBlending
                            selected_row.Cells[21].Value = Convert.ToInt32(clipboard_data[21]);       // m_nSrcBlend
                            selected_row.Cells[22].Value = Convert.ToInt32(clipboard_data[22]);       // m_nDestBlend
                            selected_row.Cells[23].Value = Convert.ToInt32(clipboard_data[23]);       // m_nTextureRenderState
                            selected_row.Cells[24].Value = Convert.ToBoolean(clipboard_data[24]);     // m_bLightMapUse
                            selected_row.Cells[25].Value = Convert.ToBoolean(clipboard_data[25]);     // m_bLightMapAlphaBlending
                            selected_row.Cells[26].Value = Convert.ToInt32(clipboard_data[26]);       // m_nLightMapSrcBlend
                            selected_row.Cells[27].Value = Convert.ToInt32(clipboard_data[27]);       // m_nLightMapDestBlend
                            selected_row.Cells[28].Value = Convert.ToInt32(clipboard_data[28]);       // m_nLightMapRenderState
                            selected_row.Cells[29].Value = Convert.ToBoolean(clipboard_data[29]);     // m_bAnimationLoop
                            selected_row.Cells[30].Value = Convert.ToSingle(clipboard_data[30]);      // m_fStartTime
                            selected_row.Cells[31].Value = Convert.ToSingle(clipboard_data[31]);      // m_fEndTime
                            selected_row.Cells[32].Value = Convert.ToBoolean(clipboard_data[32]);     // m_bObjectAnimationLoop
                            selected_row.Cells[33].Value = Convert.ToInt32(clipboard_data[33]);       // m_nColorLoop
                            selected_row.Cells[34].Value = Convert.ToBoolean(clipboard_data[34]);     // m_bUseEnvironmentLight
                            selected_row.Cells[35].Value = Convert.ToBoolean(clipboard_data[35]);     // m_bAlphaTestEnble
                            selected_row.Cells[36].Value = Convert.ToInt32(clipboard_data[36]);       // m_nAlphaTestValue
                            selected_row.Cells[37].Value = Convert.ToBoolean(clipboard_data[37]);     // m_bZWriteEnable
                            break;
                        case Defines.SPRITE:
                            if (clipboard_data.Length != 30)
                            {
                                MessageBox.Show("Trying to paste row of the wrong type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            selected_row.Cells[3].Value = clipboard_data[3];                          // m_strName
                            selected_row.Cells[4].Value = Convert.ToInt32(clipboard_data[4]);         // m_nTextureVertexBufferType
                            selected_row.Cells[5].Value = Convert.ToSingle(clipboard_data[5]);        // m_fTextureSize
                            selected_row.Cells[6].Value = Convert.ToSingle(clipboard_data[6]);        // m_fVel
                            selected_row.Cells[7].Value = Convert.ToSingle(clipboard_data[7]);        // m_fTick
                            selected_row.Cells[8].Value = Convert.ToBoolean(clipboard_data[8]);       // m_bZbufferEnable
                            selected_row.Cells[9].Value = Convert.ToSingle(clipboard_data[9]);        // m_cColor.R
                            selected_row.Cells[10].Value = Convert.ToSingle(clipboard_data[10]);      // m_cColor.G
                            selected_row.Cells[11].Value = Convert.ToSingle(clipboard_data[11]);      // m_cColor.B
                            selected_row.Cells[12].Value = Convert.ToSingle(clipboard_data[12]);      // m_cColor.a
                            selected_row.Cells[13].Value = Convert.ToSingle(clipboard_data[13]);      // m_cColorStep.r
                            selected_row.Cells[14].Value = Convert.ToSingle(clipboard_data[14]);      // m_cColorStep.g
                            selected_row.Cells[15].Value = Convert.ToSingle(clipboard_data[15]);      // m_cColorStep.b
                            selected_row.Cells[16].Value = Convert.ToSingle(clipboard_data[16]);      // m_cColorStep.a
                            selected_row.Cells[17].Value = Convert.ToSingle(clipboard_data[17]);      // m_fColorChangeStartTime
                            selected_row.Cells[18].Value = Convert.ToBoolean(clipboard_data[18]);     // m_bAlphaBlending
                            selected_row.Cells[19].Value = clipboard_data[19];                        // m_strTextureFile
                            selected_row.Cells[20].Value = Convert.ToInt32(clipboard_data[20]);       // m_nSrcBlend
                            selected_row.Cells[21].Value = Convert.ToInt32(clipboard_data[21]);       // m_nDestBlend
                            selected_row.Cells[22].Value = Convert.ToInt32(clipboard_data[22]);       // m_nTextureRenderState
                            selected_row.Cells[23].Value = Convert.ToBoolean(clipboard_data[23]);     // m_bLightMapAlphaBlending
                            selected_row.Cells[24].Value = clipboard_data[24];                        // m_strLightMapFile
                            selected_row.Cells[25].Value = Convert.ToInt32(clipboard_data[25]);       // m_nLightMapSrcBlend
                            selected_row.Cells[26].Value = Convert.ToInt32(clipboard_data[26]);       // m_nLightMapDestBlend
                            selected_row.Cells[27].Value = Convert.ToInt32(clipboard_data[27]);       // m_nLightMapRenderState
                            selected_row.Cells[28].Value = Convert.ToInt32(clipboard_data[28]);       // m_nColorLoop
                            selected_row.Cells[29].Value = Convert.ToBoolean(clipboard_data[29]);     // m_bZWriteEnable
                            break;
                        case Defines.PARTICLE:
                            if (clipboard_data.Length != 62)
                            {
                                MessageBox.Show("Trying to paste row of the wrong type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            selected_row.Cells[3].Value =   clipboard_data[3];                          // m_strName
                            selected_row.Cells[4].Value =   Convert.ToBoolean(clipboard_data[4]);       // m_bLoop
                            selected_row.Cells[5].Value =   Convert.ToSingle(clipboard_data[5]);        // m_fDelayTime
                            selected_row.Cells[6].Value =   Convert.ToSingle(clipboard_data[6]);        // m_fCurrentDelayTime
                            selected_row.Cells[7].Value =   Convert.ToUInt32(clipboard_data[7]);        // m_dwDestBlend
                            selected_row.Cells[8].Value =   Convert.ToUInt32(clipboard_data[8]);        // m_dwSrcBlend
                            selected_row.Cells[9].Value =   Convert.ToInt32(clipboard_data[9]);         // m_nEmitMass
                            selected_row.Cells[10].Value =  Convert.ToSingle(clipboard_data[10]);      // m_fEmitTime
                            selected_row.Cells[11].Value =  Convert.ToSingle(clipboard_data[11]);      // m_fCurrentEmitTime
                            selected_row.Cells[12].Value =  Convert.ToSingle(clipboard_data[12]);      // m_fGravity
                            selected_row.Cells[13].Value =  Convert.ToSingle(clipboard_data[13]);      // m_fEmitLifeTime
                            selected_row.Cells[14].Value =  Convert.ToSingle(clipboard_data[14]);      // m_fCurrentEmitLifeTime
                            selected_row.Cells[15].Value =  Convert.ToSingle(clipboard_data[15]);      // m_fParticleLifeTime
                            selected_row.Cells[16].Value =  Convert.ToSingle(clipboard_data[16]);      // m_cStartColor.R
                            selected_row.Cells[17].Value =  Convert.ToSingle(clipboard_data[17]);      // m_cStartColor.G
                            selected_row.Cells[18].Value =  Convert.ToSingle(clipboard_data[18]);      // m_cStartColor.B
                            selected_row.Cells[19].Value =  Convert.ToSingle(clipboard_data[19]);      // m_cStartColor.a
                            selected_row.Cells[20].Value =  Convert.ToSingle(clipboard_data[20]);      // m_cColorVel.r
                            selected_row.Cells[21].Value =  Convert.ToSingle(clipboard_data[21]);      // m_cColorVel.g
                            selected_row.Cells[22].Value =  Convert.ToSingle(clipboard_data[22]);      // m_cColorVel.b
                            selected_row.Cells[23].Value =  Convert.ToSingle(clipboard_data[23]);      // m_cColorVel.a
                            selected_row.Cells[24].Value =  Convert.ToSingle(clipboard_data[24]);      // m_vPos.x
                            selected_row.Cells[25].Value =  Convert.ToSingle(clipboard_data[25]);      // m_vPos.y
                            selected_row.Cells[26].Value =  Convert.ToSingle(clipboard_data[26]);      // m_vPos.z
                            selected_row.Cells[27].Value =  Convert.ToSingle(clipboard_data[27]);      // m_vVel.x
                            selected_row.Cells[28].Value =  Convert.ToSingle(clipboard_data[28]);      // m_vVel.y
                            selected_row.Cells[29].Value =  Convert.ToSingle(clipboard_data[29]);      // m_vVel.z
                            selected_row.Cells[30].Value =  Convert.ToSingle(clipboard_data[30]);      // m_fTextureSizeVel
                            selected_row.Cells[31].Value =  Convert.ToSingle(clipboard_data[31]);      // m_fTextureStartSize
                            selected_row.Cells[32].Value =  Convert.ToSingle(clipboard_data[32]);      // m_fTextureSizeMax
                            selected_row.Cells[33].Value =  Convert.ToSingle(clipboard_data[33]);      // m_fTextureSizeMin
                            selected_row.Cells[34].Value =  Convert.ToSingle(clipboard_data[34]);      // m_fTick
                            selected_row.Cells[35].Value =  Convert.ToInt32(clipboard_data[35]);       // m_nTextureSizeChangeType
                            selected_row.Cells[36].Value =  Convert.ToSingle(clipboard_data[36]);      // m_fCurrentTick
                            selected_row.Cells[37].Value =  Convert.ToSingle(clipboard_data[37]);      // m_vDir.x
                            selected_row.Cells[38].Value =  Convert.ToSingle(clipboard_data[38]);      // m_vDir.y
                            selected_row.Cells[39].Value =  Convert.ToSingle(clipboard_data[39]);      // m_vDir.z
                            selected_row.Cells[40].Value =  Convert.ToSingle(clipboard_data[40]);      // m_vArea.x
                            selected_row.Cells[41].Value =  Convert.ToSingle(clipboard_data[41]);      // m_vArea.y
                            selected_row.Cells[42].Value =  Convert.ToSingle(clipboard_data[42]);      // m_vArea.z
                            selected_row.Cells[43].Value =  Convert.ToBoolean(clipboard_data[43]);     // m_bCreateRandom
                            selected_row.Cells[44].Value =  Convert.ToSingle(clipboard_data[44]);      // m_fCircleForce
                            selected_row.Cells[45].Value =  Convert.ToSingle(clipboard_data[45]);      // m_fCreateDensity
                            selected_row.Cells[46].Value =  Convert.ToSingle(clipboard_data[46]);      // m_fEmitRadius
                            selected_row.Cells[47].Value =  Convert.ToSingle(clipboard_data[47]);      // m_fRotateAngle
                            selected_row.Cells[48].Value =  Convert.ToSingle(clipboard_data[48]);      // m_fTextureAnimationTime
                            selected_row.Cells[49].Value =  Convert.ToInt32(clipboard_data[49]);       // m_nEmitterType
                            selected_row.Cells[50].Value =  Convert.ToInt32(clipboard_data[50]);       // m_nTextureAnimationType
                            selected_row.Cells[51].Value =  Convert.ToInt32(clipboard_data[51]);       // m_nParticleType
                            selected_row.Cells[52].Value =  Convert.ToSingle(clipboard_data[52]);      // m_fEmitAngle
                            selected_row.Cells[53].Value =  Convert.ToInt32(clipboard_data[53]);       // m_nTextureNumber
                            selected_row.Cells[54].Value =  Convert.ToInt32(clipboard_data[54]);       // m_nPersistence
                            selected_row.Cells[55].Value =  Convert.ToBoolean(clipboard_data[55]);     // m_bZbufferEnable
                            selected_row.Cells[56].Value =  Convert.ToSingle(clipboard_data[56]);      // m_fColorChangeStartTime
                            selected_row.Cells[57].Value =  Convert.ToInt32(clipboard_data[57]);       // m_nColorLoop
                            selected_row.Cells[58].Value =  Convert.ToInt32(clipboard_data[58]);       // m_nObjCreateTargetType
                            selected_row.Cells[59].Value =  Convert.ToInt32(clipboard_data[59]);       // m_nObjCreateUpType
                            selected_row.Cells[60].Value =  Convert.ToInt32(clipboard_data[60]);       // m_nObjMoveTargetType
                            selected_row.Cells[61].Value =  Convert.ToBoolean(clipboard_data[61]);     // m_bZWriteEnable
                            break;
                        case Defines.TRACE:
                            if (clipboard_data.Length != 18)
                            {
                                MessageBox.Show("Trying to paste row of the wrong type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            selected_row.Cells[3].Value =   Convert.ToUInt32(clipboard_data[3]);        // dwType
                            selected_row.Cells[4].Value =   Convert.ToSingle(clipboard_data[4]);        // fDistance
                            selected_row.Cells[5].Value =   clipboard_data[5];                          // m_strName
                            selected_row.Cells[6].Value =   Convert.ToUInt32(clipboard_data[6]);        // m_nNumberOfTrace
                            selected_row.Cells[7].Value =   Convert.ToSingle(clipboard_data[7]);        // m_fCreateTick
                            selected_row.Cells[8].Value =   Convert.ToSingle(clipboard_data[8]);        // m_fHalfSize
                            selected_row.Cells[9].Value =   Convert.ToUInt32(clipboard_data[9]);        // m_nTextureNumber
                            selected_row.Cells[10].Value =  Convert.ToSingle(clipboard_data[10]);      // m_fTextureAnimationTime
                            selected_row.Cells[11].Value =  Convert.ToInt32(clipboard_data[11]);       // m_nNumberOfCross
                            selected_row.Cells[12].Value =  Convert.ToBoolean(clipboard_data[12]);     // m_bAlphaBlendEnable
                            selected_row.Cells[13].Value =  Convert.ToUInt32(clipboard_data[13]);      // m_dwSrcBlend
                            selected_row.Cells[14].Value =  Convert.ToUInt32(clipboard_data[14]);      // m_dwDestBlend
                            selected_row.Cells[15].Value =  Convert.ToUInt32(clipboard_data[15]);      // m_nTextureRenderState
                            selected_row.Cells[16].Value =  Convert.ToBoolean(clipboard_data[16]);     // m_bZbufferEnable
                            selected_row.Cells[17].Value =  Convert.ToBoolean(clipboard_data[17]);     // m_bZWriteEnable
                            break;
                        case Defines.OBJECTINFO_OBJECT:
                            if(clipboard_data.Length == 20)
                            {
                                selected_row.Cells[0].Value =   Convert.ToInt32(clipboard_data[0]);
                                selected_row.Cells[1].Value =   clipboard_data[1];
                                selected_row.Cells[2].Value =   Convert.ToSingle(clipboard_data[2]);
                                selected_row.Cells[3].Value =   Convert.ToSingle(clipboard_data[3]);
                                selected_row.Cells[4].Value =   Convert.ToSingle(clipboard_data[4]);
                                selected_row.Cells[5].Value =   Convert.ToSingle(clipboard_data[5]);
                                selected_row.Cells[6].Value =   Convert.ToSingle(clipboard_data[6]);
                                selected_row.Cells[7].Value =   Convert.ToSingle(clipboard_data[7]);
                                selected_row.Cells[8].Value =   Convert.ToSingle(clipboard_data[8]);
                                selected_row.Cells[9].Value =   Convert.ToSingle(clipboard_data[9]);
                                selected_row.Cells[10].Value =  Convert.ToSingle(clipboard_data[10]);
                                selected_row.Cells[11].Value =  Convert.ToSingle(clipboard_data[11]);
                                selected_row.Cells[12].Value =  Convert.ToBoolean(clipboard_data[12]);
                                selected_row.Cells[13].Value =  Convert.ToSingle(clipboard_data[13]);
                                selected_row.Cells[14].Value =  Convert.ToSingle(clipboard_data[14]);
                                selected_row.Cells[15].Value =  Convert.ToSingle(clipboard_data[15]);
                                selected_row.Cells[16].Value =  Convert.ToSingle(clipboard_data[16]);
                                selected_row.Cells[17].Value =  Convert.ToSingle(clipboard_data[17]);
                                selected_row.Cells[18].Value =  Convert.ToBoolean(clipboard_data[18]);
                                selected_row.Cells[19].Value =  Convert.ToBoolean(clipboard_data[19]);

                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_nEffectType =              Convert.ToInt32(clipboard_data[0]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_strEffectName =            clipboard_data[1].ToAceCharArray();
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_vPos.set(Convert.ToSingle(clipboard_data[2]), Convert.ToSingle(clipboard_data[3]), Convert.ToSingle(clipboard_data[4]));
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_vTarget.set(Convert.ToSingle(clipboard_data[5]), Convert.ToSingle(clipboard_data[6]), Convert.ToSingle(clipboard_data[7]));
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_vUp.set(Convert.ToSingle(clipboard_data[8]), Convert.ToSingle(clipboard_data[9]), Convert.ToSingle(clipboard_data[10]));
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_fStartTime =               Convert.ToSingle(clipboard_data[11]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_bUseBillboard =            Convert.ToInt32(Convert.ToBoolean(clipboard_data[12]));
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_fBillboardAngle =          Convert.ToSingle(clipboard_data[13]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_fBillboardRotateAngle =    Convert.ToSingle(clipboard_data[14]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_fBillboardRotatePerSec =   Convert.ToSingle(clipboard_data[15]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_fRandomUpLargeAngle =      Convert.ToSingle(clipboard_data[16]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_fRandomUpSmallAngle =      Convert.ToSingle(clipboard_data[17]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_bUseCharacterMatrix =      Convert.ToInt32(Convert.ToBoolean(clipboard_data[18]));
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[selected_row.Index].m_bGroundBillboard =         Convert.ToInt32(Convert.ToBoolean(clipboard_data[19]));
                            }
                            else if(clipboard_data.Length == 13)
                            {
                                //selected_row.Cells[0].Value = Convert.ToUInt64(clipboard_data[0]);
                                //selected_row.Cells[1].Value = clipboard_data[1];
                                selected_row.Cells[2].Value = Convert.ToBoolean(clipboard_data[2]);
                                selected_row.Cells[3].Value = Convert.ToInt32(clipboard_data[3]);
                                selected_row.Cells[4].Value = Convert.ToInt32(clipboard_data[4]);
                                selected_row.Cells[5].Value = Convert.ToInt32(clipboard_data[5]);
                               // selected_row.Cells[6].Value = Convert.ToInt32(clipboard_data[6]);
                                selected_row.Cells[7].Value = Convert.ToSingle(clipboard_data[7]);
                                selected_row.Cells[8].Value = Convert.ToSingle(clipboard_data[8]);
                                selected_row.Cells[9].Value = Convert.ToBoolean(clipboard_data[9]);
                                selected_row.Cells[10].Value = Convert.ToBoolean(clipboard_data[10]);
                                selected_row.Cells[11].Value = Convert.ToSingle(clipboard_data[11]);
                                selected_row.Cells[12].Value = clipboard_data[12];

                                //OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nBodyCondition = Convert.ToUInt64(clipboard_data[0]);
                                //OBJECTData.data[GlobalValues.CurrentBodyCondition].m_strBodyConditionName = clipboard_data[1].ToAceCharArray();
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_bCharacterAlphaBlending = Convert.ToInt32(Convert.ToBoolean(clipboard_data[2]));
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nCharacterTextureRenderState = Convert.ToInt32(clipboard_data[3]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nCharacterDestBlend = Convert.ToInt32(clipboard_data[4]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nCharacterSrcBlend = Convert.ToInt32(clipboard_data[5]);
                                //OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nEffectNumber = Convert.ToInt32(clipboard_data[6]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_fStartAnimationTime = Convert.ToSingle(clipboard_data[7]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_fEndAnimationTime = Convert.ToSingle(clipboard_data[8]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_bCharacterRendering = Convert.ToInt32(Convert.ToBoolean(clipboard_data[9]));
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_bNotAnimationLooping = Convert.ToInt32(Convert.ToBoolean(clipboard_data[10]));
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_fAnimationVel = Convert.ToSingle(clipboard_data[11]);
                                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_strSoundFileName = clipboard_data[12].ToAceCharArray();
                            }
                            break;
                    }
                    if (GlobalValues.CurrentForm.Text[GlobalValues.CurrentForm.Text.Length - 1] != '*')
                        GlobalValues.CurrentForm.Text = GlobalValues.CurrentForm.Text + "*";
                    GlobalValues.FileSaved = false;
                }
                #endregion
            }
            else if (e.Control && e.KeyCode == Keys.S && !e.Shift)
            {
                infoHandling.SaveInfoFile(MainGrid, TextureNameGrid);
                //SaveEffectFile();

            }
            else if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                if (IE_SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GlobalValues.FilePath = IE_SaveFileDialog.FileName;
                    // My own safety bypsass :D
                    GlobalValues.FileSaved = false;
                    infoHandling.SaveInfoFile(MainGrid, TextureNameGrid);
                    //SaveEffectFile();
                }
            }
        }       


        private void CurrentlySelected_Enter(object sender, EventArgs e)
        {
            if(MainGrid.Focused)          
                TextureNameGrid.ClearSelection();            
            else if(TextureNameGrid.Focused)          
                MainGrid.ClearSelection();         
        }

        #region Cell End Edit
        private void MainGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the value is empty, if yes then set the value to 0
            if (MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.GetType() != MainGrid.Columns[e.ColumnIndex].ValueType && MainGrid.Columns[e.ColumnIndex].ValueType != typeof(string))
                MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            else if(MainGrid.Columns[e.ColumnIndex].ValueType == typeof(string) && MainGrid.Rows[0].Cells[e.ColumnIndex].Value.ToString().Length <= 0)
                TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0";

            if (GlobalValues.CurrentForm.Text[GlobalValues.CurrentForm.Text.Length - 1] != '*')
                GlobalValues.CurrentForm.Text = GlobalValues.CurrentForm.Text + "*";
            GlobalValues.FileSaved = false;           
        }
        private void TextureNameGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Kind of a hack, but that's kinda needed to stop it from not deleting a value that should've been deleted
            if (TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length <= 0)
                TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0";

            if (GlobalValues.CurrentForm.Text[GlobalValues.CurrentForm.Text.Length - 1] != '*')
                GlobalValues.CurrentForm.Text = GlobalValues.CurrentForm.Text + "*";
            GlobalValues.FileSaved = false;
        }
        #endregion

        #region Error Handling
        private void GridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Unexpected Error!\n" + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            // If someone is retarded enough to put in the wrong data type cancel the edit
            if (MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.GetType() != MainGrid.Columns[e.ColumnIndex].ValueType)        
                MainGrid.CancelEdit();
        }
        #endregion

        #region Tool Menu
        #region File
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IE_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                GlobalValues.FilePath = IE_OpenFileDialog.FileName;
                infoHandling.OpenInfoFile(MainGrid, TextureNameGrid);
            }           
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoHandling.SaveInfoFile(MainGrid, TextureNameGrid);
            //SaveEffectFile();            
        }       
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(IE_SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                GlobalValues.FilePath = IE_SaveFileDialog.FileName;
                // My own safety bypsass :D
                GlobalValues.FileSaved = false;
                infoHandling.SaveInfoFile(MainGrid, TextureNameGrid);
                //SaveEffectFile();
            }
        }

        #endregion

        #region Presets

        #endregion

        #region Opacity
        private void Opacity100_Click(object sender, EventArgs e)
        {
            fc.SetOpacity(1);
        }

        private void Opacity90_Click(object sender, EventArgs e)
        {
            fc.SetOpacity(0.9);
        }

        private void Opacity80_Click(object sender, EventArgs e)
        {
            fc.SetOpacity(0.8);
        }

        private void Opacity70_Click(object sender, EventArgs e)
        {
            fc.SetOpacity(0.7);
        }


        #endregion

        #endregion

        private void MainGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(GlobalValues.EffectType == Defines.OBJECTINFO_OBJECT)
            {
                GlobalValues.CurrentBodyCondition = (ulong)MainGrid.Rows[e.RowIndex].Cells[0].Value;
                if (OBJECTData.data[GlobalValues.CurrentBodyCondition] != null)
                {
                    // I need to create a temporary DataTable Value because
                    // Otherwise I won't be able to alter the data
                    DataTable Effects = (DataTable)TextureNameGrid.DataSource;

                    // Clear the table if data exists. For Ovious Reasons
                    if (TextureNameGrid.Rows.Count > 1)
                        Effects.Rows.Clear();
                    foreach (var n in OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect)
                    {
                        Effects.Rows.Add(
                            n.m_nEffectType,
                            new string(n.m_strEffectName),
                            n.m_vPos.x,
                            n.m_vPos.y,
                            n.m_vPos.z,
                            n.m_vTarget.x,
                            n.m_vTarget.y,
                            n.m_vTarget.z,
                            n.m_vUp.x,
                            n.m_vUp.y,
                            n.m_vUp.z,
                            n.m_fStartTime,
                            n.m_bUseBillboard,
                            n.m_fBillboardAngle,
                            n.m_fBillboardRotateAngle,
                            n.m_fBillboardRotatePerSec,
                            n.m_fRandomUpLargeAngle,
                            n.m_fRandomUpSmallAngle,
                            n.m_bUseCharacterMatrix,
                            n.m_bGroundBillboard
                            );
                        Effects.AcceptChanges();
                    }
                }
            }        
        }

        private void TextureNameGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GlobalValues.EffectType == Defines.OBJECTINFO_OBJECT)
            {
                // For now it'll do. I have no better Ideas for it as of right now
                switch(e.ColumnIndex)
                {
                    case 0: // m_nEffectType
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_nEffectType = (int)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 1: // m_strEffectName
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_strEffectName = TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToAceCharArray();
                        break;
                    case 2: // m_vPos X
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vPos.x = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 3: // m_vPos Y
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vPos.y = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 4: // m_vPos Z
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vPos.z = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 5: // m_vTarget X 
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vTarget.x = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 6: // m_vTarget Y
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vTarget.y = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 7: // m_vTarget Z
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vTarget.z = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 8: // m_vUp X
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vUp.x = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 9: // m_vUp Y
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vUp.y = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 10: // m_vUp Z
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_vUp.z = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 11: // m_fStartTime
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_fStartTime = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 12: // m_bUseBillboard
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_bUseBillboard = Convert.ToInt32(TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        break;
                    case 13: // m_fBillboardAngle
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_fBillboardAngle = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 14: // m_fBillboardRotateAngle
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_fBillboardRotateAngle = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 15: // m_fBillboardRotatePerSec
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_fBillboardRotatePerSec = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 16: // m_fRandomUpLargeAngle
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_fRandomUpLargeAngle = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 17: // m_fRandomUpSmallAngle
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_fRandomUpSmallAngle = (float)TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 18: // m_bUseCharacterMatrix
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_bUseCharacterMatrix = Convert.ToInt32(TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        break;
                    case 19: // m_bGroundBillboard
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect[e.RowIndex].m_bGroundBillboard = Convert.ToInt32(TextureNameGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        break;                 
                }
            }
        }

        private void MainGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (GlobalValues.EffectType == Defines.OBJECTINFO_OBJECT)
            {
                // For now it'll do. I have no better Ideas for it as of right now
                switch (e.ColumnIndex)
                {
                    case 0: // m_nBodyCondition
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nBodyCondition = (ulong)MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 1: // m_strBodyConditionName
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_strBodyConditionName = MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToAceCharArray();
                        break;
                    case 2: // m_bCharacterAlphaBlending
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_bCharacterAlphaBlending = Convert.ToInt32(MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        break;
                    case 3: // m_nCharacterTextureRenderState
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nCharacterTextureRenderState = (int)MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 4: // m_nCharacterDestBlend
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nCharacterDestBlend = (int)MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 5: // m_nCharacterSrcBlend 
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nCharacterSrcBlend = (int)MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 6: // m_nEffectNumber
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nEffectNumber = (int)MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 7: // m_fStartAnimationTime
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_fStartAnimationTime = (float)MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 8: // m_fEndAnimationTime
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_fEndAnimationTime = (float)MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 9: // m_bCharacterRendering
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_bCharacterRendering = Convert.ToInt32(MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        break;
                    case 10: // m_bNotAnimationLooping
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_bNotAnimationLooping = Convert.ToInt32(MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        break;
                    case 11: // m_fAnimationVel
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_fAnimationVel = (float)MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        break;
                    case 12: // m_strSoundFileName
                        OBJECTData.data[GlobalValues.CurrentBodyCondition].m_strSoundFileName = MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToAceCharArray();
                        break;                    
                }
            }
        }

        private void TextureNameGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (GlobalValues.CurrentBodyCondition != 0)
            {
                _EffectInfo effectinfo = new _EffectInfo();

                // I REALLY REALLY didn't want to do this.
                // But oh well...
                #region Create new EffectInfo of BodyConditionData
                // m_nEffectType
                if (e.Row.Cells[0].Value != null)
                    effectinfo.m_nEffectType = (int)e.Row.Cells[0].Value;
                else
                    effectinfo.m_nEffectType = 0;

                // m_strEffectName
                if (e.Row.Cells[1].Value != null)
                    effectinfo.m_strEffectName = e.Row.Cells[1].Value.ToString().ToAceCharArray();
                else
                    effectinfo.m_strEffectName = new char[20];

                // m_vPos
                if (e.Row.Cells[2].Value != null)
                    effectinfo.m_vPos.x = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vPos.x = 0;
                if (e.Row.Cells[3].Value != null)
                    effectinfo.m_vPos.y = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vPos.y = 0;
                if (e.Row.Cells[4].Value != null)
                    effectinfo.m_vPos.z = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vPos.z = 0;

                // m_vTarget
                if (e.Row.Cells[5].Value != null)
                    effectinfo.m_vTarget.x = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vTarget.x = 0;
                if (e.Row.Cells[6].Value != null)
                    effectinfo.m_vTarget.y = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vTarget.y = 0;
                if (e.Row.Cells[7].Value != null)
                    effectinfo.m_vTarget.z = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vTarget.z = 0;

                // m_vUp
                if (e.Row.Cells[8].Value != null)
                    effectinfo.m_vUp.x = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vUp.x = 0;
                if (e.Row.Cells[9].Value != null)
                    effectinfo.m_vUp.y = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vUp.y = 0;
                if (e.Row.Cells[10].Value != null)
                    effectinfo.m_vUp.z = (float)e.Row.Cells[2].Value;
                else
                    effectinfo.m_vUp.z = 0;

                // m_fStartTime
                if (e.Row.Cells[11].Value != null)
                    effectinfo.m_fStartTime = (float)e.Row.Cells[11].Value;
                else
                    effectinfo.m_fStartTime = 0;

                // m_bUseBillboard
                if (e.Row.Cells[12].Value != null)
                    effectinfo.m_bUseBillboard = Convert.ToInt32(e.Row.Cells[12].Value);
                else
                    effectinfo.m_bUseBillboard = 0;

                // m_fBillboardAngle
                if (e.Row.Cells[13].Value != null)
                    effectinfo.m_fBillboardAngle = (float)e.Row.Cells[13].Value;
                else
                    effectinfo.m_fBillboardAngle = 0;

                // m_fBillboardRotateAngle
                if (e.Row.Cells[14].Value != null)
                    effectinfo.m_fBillboardRotateAngle = (float)e.Row.Cells[14].Value;
                else
                    effectinfo.m_fBillboardRotateAngle = 0;

                // m_fBillboardRotatePerSec
                if (e.Row.Cells[15].Value != null)
                    effectinfo.m_fBillboardRotatePerSec = (float)e.Row.Cells[15].Value;
                else
                    effectinfo.m_fBillboardRotatePerSec = 0;

                // m_fRandomUpLargeAngle
                if (e.Row.Cells[16].Value != null)
                    effectinfo.m_fRandomUpLargeAngle = (float)e.Row.Cells[16].Value;
                else
                    effectinfo.m_fRandomUpLargeAngle = 0;

                // m_fRandomUpSmallAngle
                if (e.Row.Cells[17].Value != null)
                    effectinfo.m_fRandomUpSmallAngle = (float)e.Row.Cells[17].Value;
                else
                    effectinfo.m_fRandomUpSmallAngle = 0;

                // m_bUseCharacterMatrix
                if (e.Row.Cells[18].Value != null)
                    effectinfo.m_bUseCharacterMatrix = Convert.ToInt32(e.Row.Cells[18].Value);
                else
                    effectinfo.m_bUseCharacterMatrix = 0;

                // m_bGroundBillboard
                if (e.Row.Cells[19].Value != null)
                    effectinfo.m_bGroundBillboard = Convert.ToInt32(e.Row.Cells[19].Value);
                else
                    effectinfo.m_bGroundBillboard = 0;

                #endregion
                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect.Add(effectinfo);
                OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nEffectNumber++;
                // Not Really a good idea. But I'm speedrunning this shit right now.
                // So it'll do
                for (int i = 0; i < OBJECTData.m_nBodyConditionNumber; i++)
                {
                    if (GlobalValues.CurrentBodyCondition == (ulong)MainGrid.Rows[i].Cells[0].Value)
                    {
                        MainGrid.Rows[i].Cells[6].Value = (int)MainGrid.Rows[i].Cells[6].Value + 1;
                        break;
                    }
                }
                if (GlobalValues.CurrentForm.Text[GlobalValues.CurrentForm.Text.Length - 1] != '*')
                    GlobalValues.CurrentForm.Text = GlobalValues.CurrentForm.Text + "*";
                GlobalValues.FileSaved = false;
            }
        }

        private void TextureNameGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect.RemoveAt(e.Row.Index + 1);

            OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nEffectNumber--;
            // Not Really a good idea. But I'm speedrunning this shit right now.
            // So it'll do
            for (int i = 0; i < OBJECTData.m_nBodyConditionNumber; i++)
            {
                if (GlobalValues.CurrentBodyCondition == (ulong)MainGrid.Rows[i].Cells[0].Value)
                {
                    MainGrid.Rows[i].Cells[6].Value = (int)MainGrid.Rows[i].Cells[6].Value - 1;
                    break;
                }
            }
            if (GlobalValues.CurrentForm.Text[GlobalValues.CurrentForm.Text.Length - 1] != '*')
                GlobalValues.CurrentForm.Text = GlobalValues.CurrentForm.Text + "*";
            GlobalValues.FileSaved = false;
        }

        private void TextureNameGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            OBJECTData.data[GlobalValues.CurrentBodyCondition].m_vecEffect.RemoveAt(e.Row.Index);

            OBJECTData.data[GlobalValues.CurrentBodyCondition].m_nEffectNumber--;
            // Not Really a good idea. But I'm speedrunning this shit right now.
            // So it'll do
            for (int i = 0; i < OBJECTData.m_nBodyConditionNumber; i++)
            {
                if (GlobalValues.CurrentBodyCondition == (ulong)MainGrid.Rows[i].Cells[0].Value)
                {
                    MainGrid.Rows[i].Cells[6].Value = (int)MainGrid.Rows[i].Cells[6].Value - 1;
                    break;
                }
            }
            if (GlobalValues.CurrentForm.Text[GlobalValues.CurrentForm.Text.Length - 1] != '*')
                GlobalValues.CurrentForm.Text = GlobalValues.CurrentForm.Text + "*";
            GlobalValues.FileSaved = false;
        }

        private void InfoEditorMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(GlobalValues.CurrentForm.Text[GlobalValues.CurrentForm.Text.Length - 1] != '*')           
                return;           

            if (MessageBox.Show("Do you want to exit without saving changes?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)                    
                e.Cancel = true;
            return;          
        }
    }
}

