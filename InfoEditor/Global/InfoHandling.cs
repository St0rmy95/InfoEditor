using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoEditor.EffectInfo;
using InfoEditor.EffectInfo.Data;
using static InfoEditor.Global.D3D9Types;
using InfoEditor.Global;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using InfoEditor.ObjectInfo.Data;
using InfoEditor.ObjectInfo;
//using ResInfoTypes;

namespace InfoEditor.Global
{   
    public class InfoHandling
    {
        // idk why I added This
        public void WriteFileData(string file_path)
        {

        }

        public void OpenInfoFile(DataGridView MainGrid, DataGridView TextureNameGrid)
        {
            // Check if the binary file has been modified without saving the changes
            if (GlobalValues.CurrentForm.Text[GlobalValues.CurrentForm.Text.Length - 1] == '*' && !GlobalValues.FileSaved)
            {
                if (MessageBox.Show("You have Unsaved Changes\nAre you sure that you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
                else
                    GlobalValues.CurrentForm.Text = "InfoEditor (" + GlobalValues.FilePath + ')';
            }

            if(GlobalValues.FilePath != null)
            {
                switch (Path.GetExtension(GlobalValues.FilePath))
                {
                    case ".bin":
                    case ".obi":
                    case ".eff":
                        if (!GetInfoType())
                            return;

                        string[] texture_name = new string[20];
                        EffInfo effi = new EffInfo();
                        DataTable MainDataTable = new DataTable("Main");
                        DataTable TextureDataTable = new DataTable("Texture Names");
                        DataRow TextureNamesDataTable = TextureDataTable.NewRow();
                       
                        // Set the grids to null to avoid any fuck ups, and previous data still being displayed
                        MainGrid.DataSource = null; TextureNameGrid.DataSource = null;                      
                        // No idea why I have to convert it Again. But for now I don't care enough to find out :V
                        switch (GlobalValues.EffectType)
                        {
                            case Defines.EFFECTINFO_OBJECT: // Object
                                OBJECT obj = new OBJECT();
                                obj = effi.ReadObject();
                                MainDataTable = CreateEffectTable();
                                #region Row Data
                                MainDataTable.Rows.Add(
                                    obj.dwProductID,
                                    obj.dwVersion,
                                    obj.dwEffectType,
                                    new string(obj.m_strName),
                                    new string(obj.m_strObjectFile),
                                    obj.m_fScale,
                                    obj.m_nObjectAniType,
                                    obj.m_fTextureAniVel,
                                    obj.m_fObjectAniVel,
                                    obj.m_fTick,
                                    obj.m_bZbufferEnable,
                                    obj.m_cColor.r,
                                    obj.m_cColor.g,
                                    obj.m_cColor.b,
                                    obj.m_cColor.a,
                                    obj.m_cColorStep.r,
                                    obj.m_cColorStep.g,
                                    obj.m_cColorStep.b,
                                    obj.m_cColorStep.a,
                                    obj.m_fColorChangeStartTime,
                                    obj.m_bAlphaBlending,
                                    obj.m_nSrcBlend,
                                    obj.m_nDestBlend,
                                    obj.m_nTextureRenderState,
                                    obj.m_bLightMapUse,
                                    obj.m_bLightMapAlphaBlending,
                                    obj.m_nLightMapSrcBlend,
                                    obj.m_nLightMapDestBlend,
                                    obj.m_nLightMapRenderState,
                                    obj.m_bAnimationLoop,
                                    obj.m_fStartTime,
                                    obj.m_fEndTime,
                                    obj.m_bObjectAnimationLoop,
                                    obj.m_nColorLoop,
                                    obj.m_bUseEnvironmentLight,
                                    obj.m_bAlphaTestEnble,
                                    obj.m_nAlphaTestValue,
                                    obj.m_bZWriteEnable
                                    );
                                #endregion
                                break;
                            case Defines.SPRITE: // Sprite
                                Sprite sprite = new Sprite();
                                sprite = effi.ReadSprite();
                                MainDataTable = CreateEffectTable();
                                #region Row Data
                                MainDataTable.Rows.Add(
                                sprite.dwProductID,
                                sprite.dwVersion,
                                sprite.dwEffectType,
                                new string(sprite.m_strName),
                                sprite.m_nTextureVertexBufferType,
                                sprite.m_fTextureSize,
                                sprite.m_fVel,
                                sprite.m_fTick,
                                sprite.m_bZbufferEnable,
                                sprite.m_cColor.r,
                                sprite.m_cColor.g,
                                sprite.m_cColor.b,
                                sprite.m_cColor.a,
                                sprite.m_cColorStep.r,
                                sprite.m_cColorStep.g,
                                sprite.m_cColorStep.b,
                                sprite.m_cColorStep.a,
                                sprite.m_fColorChangeStartTime,
                                sprite.m_bAlphaBlending,
                                new string(sprite.m_strTextureFile),
                                sprite.m_nSrcBlend,
                                sprite.m_nDestBlend,
                                sprite.m_nTextureRenderState,
                                sprite.m_bLightMapAlphaBlending,
                                new string(sprite.m_strLightMapFile),
                                sprite.m_nLightMapSrcBlend,
                                sprite.m_nLightMapDestBlend,
                                sprite.m_nLightMapRenderState,
                                sprite.m_nColorLoop,
                                sprite.m_bZWriteEnable
                                );
                                #endregion
                                break;
                            case Defines.PARTICLE: // Particle
                                Particle particle = new Particle();
                                particle = effi.ReadParticle();
                                MainDataTable = CreateEffectTable();

                                // Texture Names Shit
                                for (int i = 0; i < 20; i++)
                                {
                                    for (int j = 0; j < 20; j++)
                                    {
                                        texture_name[i] += particle.m_strTextureName[i, j].ToString();
                                    }
                                    TextureDataTable.Columns.Add("Texture Name " + (i + 1), typeof(string));
                                    TextureNamesDataTable["Texture Name " + (i + 1)] = texture_name[i];
                                }
                                TextureDataTable.Rows.Add(TextureNamesDataTable);
                                #region Row Data
                                MainDataTable.Rows.Add(
                                        particle.dwProductID,
                                        particle.dwVersion,
                                        particle.dwEffectType,
                                        new string(particle.m_strName),
                                        particle.m_bLoop,
                                        particle.m_fDelayTime,
                                        particle.m_fCurrentDelayTime,
                                        particle.m_dwDestBlend,
                                        particle.m_dwSrcBlend,
                                        particle.m_nEmitMass,
                                        particle.m_fEmitTime,
                                        particle.m_fCurrentEmitTime,
                                        particle.m_fGravity,
                                        particle.m_fEmitLifeTime,
                                        particle.m_fCurrentEmitLifeTime,
                                        particle.m_fParticleLifeTime,
                                        particle.m_cStartColor.r,
                                        particle.m_cStartColor.g,
                                        particle.m_cStartColor.b,
                                        particle.m_cStartColor.a,
                                        particle.m_cColorVel.r,
                                        particle.m_cColorVel.g,
                                        particle.m_cColorVel.b,
                                        particle.m_cColorVel.a,
                                        particle.m_vPos.x,
                                        particle.m_vPos.y,
                                        particle.m_vPos.z,
                                        particle.m_vVel.x,
                                        particle.m_vVel.y,
                                        particle.m_vVel.z,
                                        particle.m_fTextureSizeVel,
                                        particle.m_fTextureStartSize,
                                        particle.m_fTextureSizeMax,
                                        particle.m_fTextureSizeMin,
                                        particle.m_fTick,
                                        particle.m_nTextureSizeChangeType,
                                        particle.m_fCurrentTick,
                                        particle.m_vDir.x,
                                        particle.m_vDir.y,
                                        particle.m_vDir.z,
                                        particle.m_vArea.x,
                                        particle.m_vArea.y,
                                        particle.m_vArea.z,
                                        particle.m_bCreateRandom,
                                        particle.m_fCircleForce,
                                        particle.m_fCreateDensity,
                                        particle.m_fEmitRadius,
                                        particle.m_fRotateAngle,
                                        particle.m_fTextureAnimationTime,
                                        particle.m_nEmitterType,
                                        particle.m_nTextureAnimationType,
                                        particle.m_nParticleType,
                                        particle.m_fEmitAngle,
                                        particle.m_nTextureNumber,
                                        particle.m_nPersistence,
                                        particle.m_bZbufferEnable,
                                        particle.m_fColorChangeStartTime,
                                        particle.m_nColorLoop,
                                        particle.m_nObjCreateTargetType,
                                        particle.m_nObjCreateUpType,
                                        particle.m_nObjMoveTargetType,
                                        particle.m_bZWriteEnable
                                    );
                                #endregion
                                TextureNameGrid.DataSource = TextureDataTable;
                                break;
                            case Defines.TRACE: // Trace
                                EffectInfo.Data.Trace trace = new EffectInfo.Data.Trace();
                                trace = effi.ReadTrace();
                                MainDataTable = CreateEffectTable();

                                for (int i = 0; i < 20; i++)
                                {
                                    for (int j = 0; j < 20; j++)
                                    {
                                        texture_name[i] += trace.m_strTextureName[i, j].ToString();
                                    }
                                    TextureDataTable.Columns.Add("Texture Name " + (i + 1), typeof(string));
                                    TextureNamesDataTable["Texture Name " + (i + 1)] = texture_name[i];
                                }                                
                                TextureDataTable.Rows.Add(TextureNamesDataTable);
                                #region Row Data
                                MainDataTable.Rows.Add(
                                        trace.dwProductID,
                                        trace.dwVersion,
                                        trace.dwEffectType,
                                        trace.dwType,
                                        trace.fDistance,
                                        new string(trace.m_strName),
                                        trace.m_nNumberOfTrace,
                                        trace.m_fCreateTick,
                                        trace.m_fHalfSize,
                                        trace.m_nTextureNumber,
                                        trace.m_fTextureAnimationTime,
                                        trace.m_nNumberOfCross,
                                        trace.m_bAlphaBlendEnable,
                                        trace.m_dwSrcBlend,
                                        trace.m_dwDestBlend,
                                        trace.m_nTextureRenderState,
                                        trace.m_bZbufferEnable,
                                        trace.m_bZWriteEnable
                                    );
                                #endregion
                                TextureNameGrid.DataSource = TextureDataTable;
                                break;
                            case Defines.OBJECTINFO_OBJECT:
                                ObjInfo obji = new ObjInfo();
                                obji.ReadBodyConditionData();
                                CreateObjectTable(MainDataTable, TextureDataTable);
                                foreach(var n in OBJECTData.data)
                                {
                                    MainDataTable.Rows.Add(
                                        n.Value.m_nBodyCondition,
                                        new string(n.Value.m_strBodyConditionName),
                                        n.Value.m_bCharacterAlphaBlending,
                                        n.Value.m_nCharacterTextureRenderState,
                                        n.Value.m_nCharacterDestBlend,
                                        n.Value.m_nCharacterSrcBlend,
                                        n.Value.m_nEffectNumber,
                                        n.Value.m_fStartAnimationTime,
                                        n.Value.m_fEndAnimationTime,
                                        n.Value.m_bCharacterRendering,
                                        n.Value.m_bNotAnimationLooping,
                                        n.Value.m_fAnimationVel,
                                        new string(n.Value.m_strSoundFileName)
                                        );
                                }
                                TextureNameGrid.DataSource = TextureDataTable;
                                break;
                        }

                        MainGrid.DataSource = MainDataTable;
                        
                        // Disable Adding rows for Effect files
                        MainGrid.AllowUserToAddRows = false;
                        if(GlobalValues.EffectType != Defines.OBJECTINFO_OBJECT)
                            TextureNameGrid.AllowUserToAddRows = false;
                        else
                            TextureNameGrid.AllowUserToAddRows = true;
                        // Change the window title to add the file path
                        GlobalValues.CurrentForm.Text = "InfoEditor (" + GlobalValues.FilePath + ')';                     
                        #region Grid Optimization
                        // DataGrid View optimiaztions, so I can open it faster
                        MainGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                        TextureNameGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                        // Set the Row Resizing manually to make the program itself faster
                        MainGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                        TextureNameGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                        // Do the same but for the Columns
                        MainGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        TextureNameGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        #endregion
                        break;
                    default:
                        MessageBox.Show("File must have either \".bin\", \".obi\" or \".eff\" Extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;                       
                }
            }
            else
            {
                MessageBox.Show("Somehow you opened the file with a path without a path?\nWTF?!", "HUH", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            GlobalValues.FileOpened = true;
        }

        public void SaveInfoFile(DataGridView MainGrid, DataGridView TextureNameGrid)
        {
            if (GlobalValues.FileOpened && !GlobalValues.FileSaved)
            {
                EffInfo effi = new EffInfo();
                DataGridViewRow row = MainGrid.Rows[0];
                DataGridViewRow row_texturename = null;

                if (TextureNameGrid.Rows.Count > 0)
                    row_texturename = TextureNameGrid.Rows[0];

                switch (GlobalValues.EffectType)
                {
                    case Defines.EFFECTINFO_OBJECT: // Object
                        OBJECT obj = new OBJECT();
                        effi.UpdateObject(obj, row);
                        effi.WriteObject(obj);
                        break;
                    case Defines.SPRITE: // Sprite
                        Sprite sprite = new Sprite();
                        effi.UpdateSprite(sprite, row);
                        effi.WriteSprite(sprite);
                        break;
                    case Defines.PARTICLE: // Particle
                        Particle particle = new Particle();
                        effi.UpdateParticle(particle, row, row_texturename);
                        effi.WriteParticle(particle);
                        break;
                    case Defines.TRACE: // Trace
                        EffectInfo.Data.Trace trace = new EffectInfo.Data.Trace();
                        effi.UpdateTrace(trace, row, row_texturename);
                        effi.WriteTrace(trace);
                        break;
                    case Defines.OBJECTINFO_OBJECT:
                        ObjInfo obji = new ObjInfo();
                        obji.WriteBodyConditionData();
                        break;
                }
                // Get the form and set the window name back to the original              
                Application.OpenForms[0].Text = "InfoEditor (" + GlobalValues.FilePath + ')';
                GlobalValues.FileSaved = true;
                //MessageBox.Show("File Written succesfully", "gagri");
            }
            else if (!GlobalValues.FileOpened)
            {
                MessageBox.Show("You don't have any Files opened!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool GetInfoType()
        {
            //GlobalValues.EffectType = 4;
           // return true;

            uint ProductID = 0;
            uint Version = 0;
            BinaryReader br = new BinaryReader(new FileStream(GlobalValues.FilePath, FileMode.Open));
            // Check if the file is empty
            if (br.BaseStream.Length <= 0)
            {
                MessageBox.Show("Binary file is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if the file is EffectInfo file
            // Read the 2 first values, which need to be 10 and then 1
            // otherwise the file is incorrect
            ProductID = br.ReadUInt32(); Version = br.ReadUInt32();
            // Read the EffectType wich is very essential
            // If we don't Read that before the rest of the file we won't know what type of effect it is
            GlobalValues.EffectType = (int)br.ReadUInt32();
            br.Close();
            // Check if the file is actually an ACE EffectInfo file
            // if the number is bigger than 3, because there are no more effect types
            if (ProductID != 10 && Version != 1)
            {
                // if it isn't then we check if it's an objectinfo file
                char[] dummy = new char[20];
                int BodyConditionNumber;
                br = new BinaryReader(new FileStream(GlobalValues.FilePath, FileMode.Open));
                dummy = Encoding.UTF8.GetChars(br.ReadBytes(20));
                BodyConditionNumber = br.ReadInt32();
                br.Close();
                if (BodyConditionNumber > 0)
                    GlobalValues.EffectType = Defines.OBJECTINFO_OBJECT;
                else
                {
                    MessageBox.Show("Binary file Structure is incorrect!\nMake sure you opened the right Binary file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }                    
            }

            return true;
        }

        static public DataTable CreateEffectTable()
        {
            DataTable Effect = new DataTable("Effect");
            Effect.Columns.Add("Product ID",    typeof(uint));
            Effect.Columns.Add("Version",       typeof(uint));
            Effect.Columns.Add("Effect Type",   typeof(uint));
            Effect.Columns["Product ID"].ReadOnly = true;
            Effect.Columns["Version"].ReadOnly = true;
            Effect.Columns["Effect Type"].ReadOnly = true;
            switch (GlobalValues.EffectType)
            {
                case Defines.EFFECTINFO_OBJECT:
                    Effect.Columns.Add("Name",                          typeof(string));
                    Effect.Columns.Add("Object File",                   typeof(string));
                    Effect.Columns.Add("Scale",                         typeof(float));
                    Effect.Columns.Add("Object Ani Type",               typeof(int));
                    Effect.Columns.Add("Texture Ani Vel",               typeof(float));
                    Effect.Columns.Add("Object Ani Vel",                typeof(float));
                    Effect.Columns.Add("Tick",                          typeof(float));
                    Effect.Columns.Add("Buffer Enable",                 typeof(bool));

                    Effect.Columns.Add("Color: Red",                    typeof(float));
                    Effect.Columns.Add("Color: Green",                  typeof(float));
                    Effect.Columns.Add("Color: Blue",                   typeof(float));
                    Effect.Columns.Add("Color: Alpha",                  typeof(float));

                    Effect.Columns.Add("Color Step: Red",               typeof(float));
                    Effect.Columns.Add("Color Step: Green",             typeof(float));
                    Effect.Columns.Add("Color Step: Blue",              typeof(float));
                    Effect.Columns.Add("Color Step: Alpha",             typeof(float));


                    Effect.Columns.Add("Color Change Start Time",       typeof(float));
                    Effect.Columns.Add("Alpha Blending",                typeof(bool));
                    Effect.Columns.Add("Source Blend",                  typeof(int));
                    Effect.Columns.Add("Destination Blend",             typeof(int));
                    Effect.Columns.Add("Texture Render State",          typeof(int));
                    Effect.Columns.Add("Light Map",                     typeof(bool));
                    Effect.Columns.Add("Light Map Alpha Blending",      typeof(bool));
                    Effect.Columns.Add("Light Map Source Blend",        typeof(int));
                    Effect.Columns.Add("Light Map Destination Blend",   typeof(int));
                    Effect.Columns.Add("Light Map Render State",        typeof(int));
                    Effect.Columns.Add("Animation Loop",                typeof(bool));
                    Effect.Columns.Add("Start Time",                    typeof(float));
                    Effect.Columns.Add("End Time",                      typeof(float));
                    Effect.Columns.Add("Object Animation Loop",         typeof(bool));
                    Effect.Columns.Add("Color Loop",                    typeof(int));
                    Effect.Columns.Add("Environment Light",             typeof(bool));
                    Effect.Columns.Add("Alpha Test Enable",             typeof(bool));
                    Effect.Columns.Add("Alpha Test Value ",             typeof(int));
                    Effect.Columns.Add("Write Enable",                  typeof(bool));

                    break;
                case Defines.SPRITE:
                    Effect.Columns.Add("Name", typeof(string));
                    Effect.Columns.Add("Texture Vertex Buffer Type", typeof(int));
                    Effect.Columns.Add("Texture Size", typeof(float));
                    Effect.Columns.Add("Velocity", typeof(float));
                    Effect.Columns.Add("Tick", typeof(float));
                    Effect.Columns.Add("Buffer Enable", typeof(bool));

                    Effect.Columns.Add("Color: Red", typeof(float));
                    Effect.Columns.Add("Color: Green", typeof(float));
                    Effect.Columns.Add("Color: Blue", typeof(float));
                    Effect.Columns.Add("Color: Alpha", typeof(float));

                    Effect.Columns.Add("Color Step: Red", typeof(float));
                    Effect.Columns.Add("Color Step: Green", typeof(float));
                    Effect.Columns.Add("Color Step: Blue", typeof(float));
                    Effect.Columns.Add("Color Step: Alpha", typeof(float));

                    Effect.Columns.Add("Color Change Start Time", typeof(float));
                    Effect.Columns.Add("Alpha Blending", typeof(bool));
                    Effect.Columns.Add("Texture File", typeof(string));
                    Effect.Columns.Add("Source Blend", typeof(int));
                    Effect.Columns.Add("Destination Blend", typeof(int));
                    Effect.Columns.Add("Texture Render State", typeof(int));
                    Effect.Columns.Add("Light Map Alpha Blending", typeof(bool));
                    Effect.Columns.Add("Light Map File", typeof(string));
                    Effect.Columns.Add("Light Map Source Blend", typeof(int));
                    Effect.Columns.Add("Light Map Destination Blend", typeof(int));
                    Effect.Columns.Add("Light Map Render State", typeof(int));
                    Effect.Columns.Add("Color Loop", typeof(int));
                    Effect.Columns.Add("Write Enable", typeof(bool));
                    break;
                case Defines.PARTICLE:
                    Effect.Columns.Add("Name", typeof(string));
                    Effect.Columns.Add("Loop", typeof(bool));
                    Effect.Columns.Add("Delay Time", typeof(float));
                    Effect.Columns.Add("Current Delay Time", typeof(float));
                    Effect.Columns.Add("Destination Blend", typeof(uint));
                    Effect.Columns.Add("Source Blend", typeof(uint));
                    Effect.Columns.Add("Emit Mass", typeof(int));
                    Effect.Columns.Add("Emit Time", typeof(float));
                    Effect.Columns.Add("Current Emit Time", typeof(float));
                    Effect.Columns.Add("Gravity", typeof(float));
                    Effect.Columns.Add("Emit Life Time", typeof(float));
                    Effect.Columns.Add("Current Emit Life Time", typeof(float));
                    Effect.Columns.Add("Particle Life Time", typeof(float));

                    Effect.Columns.Add("Start Color: Red", typeof(float));
                    Effect.Columns.Add("Start Color: Green", typeof(float));
                    Effect.Columns.Add("Start Color: Blue", typeof(float));
                    Effect.Columns.Add("Start Color: Alpha", typeof(float));

                    Effect.Columns.Add("Color Velocity: Red", typeof(float));
                    Effect.Columns.Add("Color Velocity: Green", typeof(float));
                    Effect.Columns.Add("Color Velocity: Blue", typeof(float));
                    Effect.Columns.Add("Color Velocity: Alpha", typeof(float));

                    Effect.Columns.Add("Position X", typeof(float));
                    Effect.Columns.Add("Position Y", typeof(float));
                    Effect.Columns.Add("Position Z", typeof(float));
                    Effect.Columns.Add("Velocity X", typeof(float));
                    Effect.Columns.Add("Velocity Y", typeof(float));
                    Effect.Columns.Add("Velocity Z", typeof(float));

                    Effect.Columns.Add("Texture Size Velocity", typeof(float));
                    Effect.Columns.Add("Texture Start Size", typeof(float));
                    Effect.Columns.Add("Texture Size Max", typeof(float));
                    Effect.Columns.Add("Texture Size Min", typeof(float));
                    Effect.Columns.Add("Tick", typeof(float));
                    Effect.Columns.Add("Texture Size Change Type", typeof(int));
                    Effect.Columns.Add("Current Tick", typeof(float));
                    Effect.Columns.Add("Direction X", typeof(float));
                    Effect.Columns.Add("Direction Y", typeof(float));
                    Effect.Columns.Add("Direction Z", typeof(float));
                    Effect.Columns.Add("Area X", typeof(float));
                    Effect.Columns.Add("Area Y", typeof(float));
                    Effect.Columns.Add("Area Z", typeof(float));
                    Effect.Columns.Add("Create Random", typeof(bool));
                    Effect.Columns.Add("Circle Force", typeof(float));
                    Effect.Columns.Add("Create Density", typeof(float));
                    Effect.Columns.Add("Emit Radius", typeof(float));
                    Effect.Columns.Add("Rotate Angle", typeof(float));
                    Effect.Columns.Add("Texture Animation Time", typeof(float));
                    Effect.Columns.Add("Emitter Type", typeof(int));
                    Effect.Columns.Add("Texture Animation Type", typeof(int));
                    Effect.Columns.Add("Particle Type", typeof(int));
                    Effect.Columns.Add("Emit Angle", typeof(float));
                    Effect.Columns.Add("Texture Number", typeof(int));
                    Effect.Columns.Add("Persistence", typeof(int));
                    Effect.Columns.Add("Buffer Enable", typeof(bool));
                    Effect.Columns.Add("Color Change Start Time", typeof(float));
                    Effect.Columns.Add("Color Loop", typeof(int));
                    Effect.Columns.Add("Object Create Target Type", typeof(int));
                    Effect.Columns.Add("Object Create Up Type", typeof(int));
                    Effect.Columns.Add("Object Move Target Type", typeof(int));
                    Effect.Columns.Add("Write Enable", typeof(bool));
                    break;
                case Defines.TRACE:
                    Effect.Columns.Add("Type", typeof(uint));
                    Effect.Columns.Add("Distance", typeof(float));
                    Effect.Columns.Add("Name", typeof(string));
                    Effect.Columns.Add("Number Of Trace", typeof(uint));
                    Effect.Columns.Add("Create Tick", typeof(float));
                    Effect.Columns.Add("Half Size", typeof(float));
                    Effect.Columns.Add("Texture Number", typeof(uint));
                    Effect.Columns.Add("Texture Animation Time", typeof(float));
                    Effect.Columns.Add("Number Of Cross", typeof(int));
                    Effect.Columns.Add("Alpha Blend Enable", typeof(bool));
                    Effect.Columns.Add("Source Blend", typeof(uint));
                    Effect.Columns.Add("Destination Blend", typeof(uint));
                    Effect.Columns.Add("Texture Render State", typeof(uint));
                    Effect.Columns.Add("Buffer Enable", typeof(bool));
                    Effect.Columns.Add("Write Enable", typeof(bool));
                    break;
            }              
            return Effect;
        }

        public void CreateObjectTable(DataTable MainDataTable, DataTable EffectDataTable)
        {
            MainDataTable.Columns.Add("Body Condition",                 typeof(ulong));
            MainDataTable.Columns["Body Condition"].ReadOnly =          true;
            MainDataTable.Columns.Add("Body Condition Name",            typeof(string));
            MainDataTable.Columns.Add("Character Alpha Blending",       typeof(bool));
            MainDataTable.Columns.Add("Character Texture Render State", typeof(int));
            MainDataTable.Columns.Add("Character Dest Blend",           typeof(int));
            MainDataTable.Columns.Add("Character Src Blend",            typeof(int));
            MainDataTable.Columns.Add("Effect Number",                  typeof(int));
            MainDataTable.Columns.Add("Start Animation Time",           typeof(float));
            MainDataTable.Columns.Add("End Animation Time",             typeof(float));
            MainDataTable.Columns.Add("Character Rendering",            typeof(bool));
            MainDataTable.Columns.Add("No tAnimation Looping",          typeof(bool));
            MainDataTable.Columns.Add("Animation Vel",                  typeof(float));
            MainDataTable.Columns.Add("SoundFileName",                  typeof(string));

            EffectDataTable.Columns.Add("Effect Type",                  typeof(int));
            EffectDataTable.Columns.Add("Effect Name",                  typeof(string));
            EffectDataTable.Columns.Add("Pos X",                        typeof(float));
            EffectDataTable.Columns.Add("Pos Y",                        typeof(float));
            EffectDataTable.Columns.Add("Pos Z",                        typeof(float));
            EffectDataTable.Columns.Add("Target X",                     typeof(float));
            EffectDataTable.Columns.Add("Target Y",                     typeof(float));
            EffectDataTable.Columns.Add("Target Z",                     typeof(float));
            EffectDataTable.Columns.Add("Up X",                         typeof(float));
            EffectDataTable.Columns.Add("Up Y",                         typeof(float));
            EffectDataTable.Columns.Add("Up Z",                         typeof(float));
            EffectDataTable.Columns.Add("Start Time",                   typeof(float));
            EffectDataTable.Columns.Add("Use Billboard",                typeof(bool));
            EffectDataTable.Columns.Add("Billboard Angle",              typeof(float));
            EffectDataTable.Columns.Add("Billboard Rotate Angle",       typeof(float));
            EffectDataTable.Columns.Add("Billboard Rotate Per Sec",     typeof(float));
            EffectDataTable.Columns.Add("Random Up Large Angle",        typeof(float));
            EffectDataTable.Columns.Add("Random Up Small Angle",        typeof(float));
            EffectDataTable.Columns.Add("Use Character Matrix",         typeof(bool));
            EffectDataTable.Columns.Add("Ground Billboard",             typeof(bool));
        }
    }
}
