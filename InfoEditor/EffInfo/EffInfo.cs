using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using InfoEditor.EffectInfo.Data;
using System.Runtime.InteropServices;
using static InfoEditor.Global.D3D9Types;
using System.Windows.Forms;
using InfoEditor.Global;

namespace InfoEditor.EffectInfo
{
    public class EffInfo
    {      
        #region Read
        public OBJECT ReadObject()
        {
            OBJECT dummy = new OBJECT();
            using (BinaryReader br = new BinaryReader(new FileStream(GlobalValues.FilePath, FileMode.Open)))
            {
                dummy.dwProductID = br.ReadUInt32();
                dummy.dwVersion = br.ReadUInt32();
                dummy.dwEffectType = br.ReadUInt32();

                dummy.m_strName = Encoding.UTF8.GetChars(br.ReadBytes(20));
                dummy.m_strObjectFile = Encoding.UTF8.GetChars(br.ReadBytes(20));

                dummy.m_fScale = br.ReadSingle();
                dummy.m_nObjectAniType = br.ReadInt32();
                dummy.m_fTextureAniVel = br.ReadSingle();
                dummy.m_fObjectAniVel = br.ReadSingle();
                dummy.m_fTick = br.ReadSingle();
                dummy.m_bZbufferEnable = br.ReadInt32();

                dummy.m_cColor.set(
                    br.ReadSingle(),
                    br.ReadSingle(),
                    br.ReadSingle(),
                    br.ReadSingle());
                dummy.m_cColorStep.set(
                    br.ReadSingle(),
                    br.ReadSingle(),
                    br.ReadSingle(),
                    br.ReadSingle());

                dummy.m_fColorChangeStartTime = br.ReadSingle();
                dummy.m_bAlphaBlending = br.ReadInt32();
                dummy.m_nSrcBlend = br.ReadInt32();
                dummy.m_nDestBlend = br.ReadInt32();
                dummy.m_nTextureRenderState = br.ReadInt32();
                dummy.m_bLightMapUse = br.ReadInt32();
                dummy.m_bLightMapAlphaBlending = br.ReadInt32();
                dummy.m_nLightMapSrcBlend = br.ReadInt32();
                dummy.m_nLightMapDestBlend = br.ReadInt32();
                dummy.m_nLightMapRenderState = br.ReadInt32();
                dummy.m_bAnimationLoop = br.ReadInt32();
                dummy.m_fStartTime = br.ReadSingle();
                dummy.m_fEndTime = br.ReadSingle();
                dummy.m_bObjectAnimationLoop = br.ReadInt32();
                dummy.m_nColorLoop = br.ReadInt32();
                dummy.m_bUseEnvironmentLight = br.ReadInt32();
                dummy.m_bAlphaTestEnble = br.ReadInt32();
                dummy.m_nAlphaTestValue = br.ReadInt32();
                dummy.m_bZWriteEnable = br.ReadInt32();
            }

            return dummy;
        }

        public Sprite ReadSprite()
        {
            Sprite dummy = new Sprite();
            using (BinaryReader br = new BinaryReader(new FileStream(GlobalValues.FilePath, FileMode.Open)))
            {
                dummy.dwProductID = br.ReadUInt32();
                dummy.dwVersion = br.ReadUInt32();
                dummy.dwEffectType = br.ReadUInt32();

                dummy.m_strName = Encoding.UTF8.GetChars(br.ReadBytes(20));

                dummy.m_nTextureVertexBufferType = br.ReadInt32();
                dummy.m_fTextureSize = br.ReadSingle();
                dummy.m_fVel = br.ReadSingle();
                dummy.m_fTick = br.ReadSingle();
                dummy.m_bZbufferEnable = br.ReadInt32();
                dummy.m_cColor = new D3DXCOLOR(br.ReadSingle(), br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                dummy.m_cColorStep = new D3DXCOLOR(br.ReadSingle(), br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                dummy.m_fColorChangeStartTime = br.ReadSingle();
                dummy.m_bAlphaBlending = br.ReadInt32();
                dummy.m_strTextureFile = Encoding.UTF8.GetChars(br.ReadBytes(20));
                dummy.m_nSrcBlend = br.ReadInt32();
                dummy.m_nDestBlend = br.ReadInt32();
                dummy.m_nTextureRenderState = br.ReadInt32();
                dummy.m_bLightMapAlphaBlending = br.ReadInt32();
                dummy.m_strLightMapFile = Encoding.UTF8.GetChars(br.ReadBytes(20));
                dummy.m_nLightMapSrcBlend = br.ReadInt32();
                dummy.m_nLightMapDestBlend = br.ReadInt32();
                dummy.m_nLightMapRenderState = br.ReadInt32();
                dummy.m_nColorLoop = br.ReadInt32();
                dummy.m_bZWriteEnable = br.ReadInt32();
            }
            return dummy;
        }

        public Particle ReadParticle()
        {
            Particle dummy = new Particle();
            using (BinaryReader br = new BinaryReader(new FileStream(GlobalValues.FilePath, FileMode.Open)))
            {
                dummy.dwProductID = br.ReadUInt32();
                dummy.dwVersion = br.ReadUInt32();
                dummy.dwEffectType = br.ReadUInt32();

                dummy.m_strName = Encoding.UTF8.GetChars(br.ReadBytes(20));
                dummy.m_bLoop = br.ReadInt32();
                dummy.m_fDelayTime = br.ReadSingle();
                dummy.m_fCurrentDelayTime = br.ReadSingle();
                dummy.m_dwDestBlend = br.ReadUInt32();
                dummy.m_dwSrcBlend = br.ReadUInt32();
                dummy.m_nEmitMass = br.ReadInt32();
                dummy.m_fEmitTime = br.ReadSingle();
                dummy.m_fCurrentEmitTime = br.ReadSingle();
                dummy.m_fGravity = br.ReadSingle();
                dummy.m_fEmitLifeTime = br.ReadSingle();
                dummy.m_fCurrentEmitLifeTime = br.ReadSingle();
                dummy.m_fParticleLifeTime = br.ReadSingle();
                dummy.m_cStartColor = new D3DXCOLOR(br.ReadSingle(), br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                dummy.m_cColorVel = new D3DXCOLOR(br.ReadSingle(), br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                dummy.m_vPos = new D3DXVECTOR3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                dummy.m_vVel = new D3DXVECTOR3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                dummy.m_fTextureSizeVel = br.ReadSingle();
                dummy.m_fTextureStartSize = br.ReadSingle();
                dummy.m_fTextureSizeMax = br.ReadSingle();
                dummy.m_fTextureSizeMin = br.ReadSingle();
                dummy.m_fTick = br.ReadSingle();
                dummy.m_nTextureSizeChangeType = br.ReadInt32();
                dummy.m_fCurrentTick = br.ReadSingle();
                dummy.m_vDir = new D3DXVECTOR3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                dummy.m_vArea = new D3DXVECTOR3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
                dummy.m_bCreateRandom = br.ReadInt32();
                dummy.m_fCircleForce = br.ReadSingle();
                dummy.m_fCreateDensity = br.ReadSingle();
                dummy.m_fEmitRadius = br.ReadSingle();
                dummy.m_fRotateAngle = br.ReadSingle();
                dummy.m_fTextureAnimationTime = br.ReadSingle();
                dummy.m_nEmitterType = br.ReadInt32();
                dummy.m_nTextureAnimationType = br.ReadInt32();
                dummy.m_nParticleType = br.ReadInt32();
                dummy.m_fEmitAngle = br.ReadSingle();
                dummy.m_nTextureNumber = br.ReadInt32();
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        dummy.m_strTextureName[i, j] = (char)br.ReadByte();
                    }
                }
                dummy.m_nPersistence = br.ReadInt32();
                dummy.m_bZbufferEnable = br.ReadInt32();
                dummy.m_fColorChangeStartTime = br.ReadSingle();
                dummy.m_nColorLoop = br.ReadInt32();
                dummy.m_nObjCreateTargetType = br.ReadInt32();
                dummy.m_nObjCreateUpType = br.ReadInt32();
                dummy.m_nObjMoveTargetType = br.ReadInt32();
                dummy.m_bZWriteEnable = br.ReadInt32();
            }
            return dummy;
        }
    
        public Trace ReadTrace()
        {
            Trace dummy = new Trace();
            using (BinaryReader br = new BinaryReader(new FileStream(GlobalValues.FilePath, FileMode.Open)))
            {
                dummy.dwProductID = br.ReadUInt32();
                dummy.dwVersion = br.ReadUInt32();
                dummy.dwEffectType = br.ReadUInt32();

                dummy.dwType = br.ReadUInt32();
                dummy.fDistance = br.ReadSingle();
                dummy.m_strName = Encoding.UTF8.GetChars(br.ReadBytes(20));
                dummy.m_nNumberOfTrace = br.ReadUInt32();
                dummy.m_fCreateTick = br.ReadSingle();
                dummy.m_fHalfSize = br.ReadSingle();
                dummy.m_nTextureNumber = br.ReadUInt32();
                dummy.m_fTextureAnimationTime = br.ReadSingle();
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        dummy.m_strTextureName[i, j] = (char)br.ReadByte();
                    }                  
                }
                dummy.m_nNumberOfCross = br.ReadInt32();
                dummy.m_bAlphaBlendEnable = br.ReadInt32();
                dummy.m_dwSrcBlend = br.ReadUInt32();
                dummy.m_dwDestBlend = br.ReadUInt32();
                dummy.m_nTextureRenderState = br.ReadUInt32();
                dummy.m_bZbufferEnable = br.ReadInt32();
                dummy.m_bZWriteEnable = br.ReadInt32();
            }
            return dummy;
        }
        #endregion

        #region Write
        public void WriteObject(OBJECT obj)
        {       
            using (BinaryWriter br = new BinaryWriter(new FileStream(GlobalValues.FilePath, FileMode.Create)))
            {
                br.Write(obj.dwProductID);
                br.Write(obj.dwVersion);
                br.Write(obj.dwEffectType);

                br.Write(obj.m_strName);
                br.Write(obj.m_strObjectFile);
                br.Write(obj.m_fScale);
                br.Write(obj.m_nObjectAniType);
                br.Write(obj.m_fTextureAniVel);
                br.Write(obj.m_fObjectAniVel);
                br.Write(obj.m_fTick);
                br.Write(obj.m_bZbufferEnable);

                br.Write(obj.m_cColor.r);
                br.Write(obj.m_cColor.g);
                br.Write(obj.m_cColor.b);
                br.Write(obj.m_cColor.a);

                br.Write(obj.m_cColorStep.r);
                br.Write(obj.m_cColorStep.g);
                br.Write(obj.m_cColorStep.b);
                br.Write(obj.m_cColorStep.a);

                br.Write(obj.m_fColorChangeStartTime);
                br.Write(obj.m_bAlphaBlending);
                br.Write(obj.m_nSrcBlend);
                br.Write(obj.m_nDestBlend);
                br.Write(obj.m_nTextureRenderState);
                br.Write(obj.m_bLightMapUse);
                br.Write(obj.m_bLightMapAlphaBlending);
                br.Write(obj.m_nLightMapSrcBlend);
                br.Write(obj.m_nLightMapDestBlend);
                br.Write(obj.m_nLightMapRenderState);
                br.Write(obj.m_bAnimationLoop);
                br.Write(obj.m_fStartTime);
                br.Write(obj.m_fEndTime);
                br.Write(obj.m_bObjectAnimationLoop);
                br.Write(obj.m_nColorLoop);
                br.Write(obj.m_bUseEnvironmentLight);
                br.Write(obj.m_bAlphaTestEnble);
                br.Write(obj.m_nAlphaTestValue);
                br.Write(obj.m_bZWriteEnable);
            }
        }

        public void WriteSprite(Sprite sprite)
        {
            using (BinaryWriter br = new BinaryWriter(new FileStream(GlobalValues.FilePath, FileMode.Create)))
            {
                br.Write(sprite.dwProductID);
                br.Write(sprite.dwVersion);
                br.Write(sprite.dwEffectType);

                br.Write(sprite.m_strName);
                br.Write(sprite.m_nTextureVertexBufferType);
                br.Write(sprite.m_fTextureSize);
                br.Write(sprite.m_fVel);
                br.Write(sprite.m_fTick);
                br.Write(sprite.m_bZbufferEnable);

                br.Write(sprite.m_cColor.r);
                br.Write(sprite.m_cColor.g);
                br.Write(sprite.m_cColor.b);
                br.Write(sprite.m_cColor.a);

                br.Write(sprite.m_cColorStep.r);
                br.Write(sprite.m_cColorStep.g);
                br.Write(sprite.m_cColorStep.b);
                br.Write(sprite.m_cColorStep.a);

                br.Write(sprite.m_fColorChangeStartTime);
                br.Write(sprite.m_bAlphaBlending);
                br.Write(sprite.m_strTextureFile);
                br.Write(sprite.m_nSrcBlend);
                br.Write(sprite.m_nDestBlend);
                br.Write(sprite.m_nTextureRenderState);
                br.Write(sprite.m_bLightMapAlphaBlending);
                br.Write(sprite.m_strLightMapFile);
                br.Write(sprite.m_nLightMapSrcBlend);
                br.Write(sprite.m_nLightMapDestBlend);
                br.Write(sprite.m_nLightMapRenderState);
                br.Write(sprite.m_nColorLoop);
                br.Write(sprite.m_bZWriteEnable);
            }
        }

        public void WriteParticle(Particle particle)
        {          
            char[] dummy = new char[20];

            using (BinaryWriter br = new BinaryWriter(new FileStream(GlobalValues.FilePath, FileMode.Create)))
            {
                br.Write(particle.dwProductID);
                br.Write(particle.dwVersion);
                br.Write(particle.dwEffectType);

                br.Write(particle.m_strName);
                br.Write(particle.m_bLoop);
                br.Write(particle.m_fDelayTime);
                br.Write(particle.m_fCurrentDelayTime);
                br.Write(particle.m_dwDestBlend);
                br.Write(particle.m_dwSrcBlend);
                br.Write(particle.m_nEmitMass);
                br.Write(particle.m_fEmitTime);
                br.Write(particle.m_fCurrentEmitTime);
                br.Write(particle.m_fGravity);
                br.Write(particle.m_fEmitLifeTime);
                br.Write(particle.m_fCurrentEmitLifeTime);
                br.Write(particle.m_fParticleLifeTime);

                br.Write(particle.m_cStartColor.r);
                br.Write(particle.m_cStartColor.g);
                br.Write(particle.m_cStartColor.b);
                br.Write(particle.m_cStartColor.a);

                br.Write(particle.m_cColorVel.r);
                br.Write(particle.m_cColorVel.g);
                br.Write(particle.m_cColorVel.b);
                br.Write(particle.m_cColorVel.a);

                br.Write(particle.m_vPos.x);
                br.Write(particle.m_vPos.y);
                br.Write(particle.m_vPos.z);

                br.Write(particle.m_vVel.x);
                br.Write(particle.m_vVel.y);
                br.Write(particle.m_vVel.z);

                br.Write(particle.m_fTextureSizeVel);
                br.Write(particle.m_fTextureStartSize);
                br.Write(particle.m_fTextureSizeMax);
                br.Write(particle.m_fTextureSizeMin);
                br.Write(particle.m_fTick);
                br.Write(particle.m_nTextureSizeChangeType);
                br.Write(particle.m_fCurrentTick);

                br.Write(particle.m_vDir.x);
                br.Write(particle.m_vDir.y);
                br.Write(particle.m_vDir.z);

                br.Write(particle.m_vArea.x);
                br.Write(particle.m_vArea.y);
                br.Write(particle.m_vArea.z);

                br.Write(particle.m_bCreateRandom);
                br.Write(particle.m_fCircleForce);
                br.Write(particle.m_fCreateDensity);
                br.Write(particle.m_fEmitRadius);
                br.Write(particle.m_fRotateAngle);
                br.Write(particle.m_fTextureAnimationTime);
                br.Write(particle.m_nEmitterType);
                br.Write(particle.m_nTextureAnimationType);
                br.Write(particle.m_nParticleType);
                br.Write(particle.m_fEmitAngle);
                br.Write(particle.m_nTextureNumber);
                // I FUCKING LOVE ACE CODE
                for(int i = 0; i < 20; i++)
                {
                    dummy = new char[20];
                    for (int j = 0; j < 20; j++)
                        if (particle.m_strTextureName[i, j] != '\0')
                            dummy[j] = particle.m_strTextureName[i, j];
                    br.Write(dummy);                 
                }
                
                br.Write(particle.m_nPersistence);
                br.Write(particle.m_bZbufferEnable);
                br.Write(particle.m_fColorChangeStartTime);
                br.Write(particle.m_nColorLoop);
                br.Write(particle.m_nObjCreateTargetType);
                br.Write(particle.m_nObjCreateUpType);
                br.Write(particle.m_nObjMoveTargetType);
                br.Write(particle.m_bZWriteEnable);
            }
        }

        public void WriteTrace(Trace trace)
        {
            char[] dummy = new char[20];

            using (BinaryWriter br = new BinaryWriter(new FileStream(GlobalValues.FilePath, FileMode.Create)))
            {
                br.Write(trace.dwProductID);
                br.Write(trace.dwVersion);
                br.Write(trace.dwEffectType);

                br.Write(trace.dwType);
                br.Write(trace.fDistance);
                br.Write(trace.m_strName);
                br.Write(trace.m_nNumberOfTrace);
                br.Write(trace.m_fCreateTick);
                br.Write(trace.m_fHalfSize);
                br.Write(trace.m_nTextureNumber);
                br.Write(trace.m_fTextureAnimationTime);
                // I FUCKING LOVE ACE CODE
                for (int i = 0; i < 20; i++)
                {
                    
                    dummy = new char[20];
                    for (int j = 0; j < 20; j++)
                        //if (trace.m_strTextureName[i, j] != '\0')
                            dummy[j] = (trace.m_strTextureName[i, j]);
                    br.Write(dummy);
                }

                br.Write(trace.m_nNumberOfCross);
                br.Write(trace.m_bAlphaBlendEnable);
                br.Write(trace.m_dwSrcBlend);
                br.Write(trace.m_dwDestBlend);
                br.Write(trace.m_nTextureRenderState);
                br.Write(trace.m_bZbufferEnable);
                br.Write(trace.m_bZWriteEnable);
            }
        }
        #endregion

        #region Update

        public void UpdateObject(OBJECT obj, DataGridViewRow row)
        {
            char[] dummy = new char[20];
            string temp;

            try
            {
                obj.dwProductID = (uint)row.Cells[0].Value;
                obj.dwVersion = (uint)row.Cells[1].Value;
                obj.dwEffectType = (uint)row.Cells[2].Value;

                temp = row.Cells[3].Value.ToString();
                for (int i = 0; i < row.Cells[3].Value.ToString().Length; i++)
                {
                    dummy[i] = temp[i];
                }
                obj.m_strName = dummy;

                dummy = new char[20]; // Creat new char array, because for some reason it commits lifen't If I don't do it
                temp = row.Cells[4].Value.ToString();
                for (int i = 0; i < row.Cells[4].Value.ToString().Length; i++)
                {
                    dummy[i] = temp[i];
                }
                obj.m_strObjectFile = dummy;

                obj.m_fScale = (float)row.Cells[5].Value;
                obj.m_nObjectAniType = (int)row.Cells[6].Value;
                obj.m_fTextureAniVel = (float)row.Cells[7].Value;
                obj.m_fObjectAniVel = (float)row.Cells[8].Value;
                obj.m_fTick = (float)row.Cells[9].Value;
                obj.m_bZbufferEnable = Convert.ToInt32(row.Cells[10].Value);

                obj.m_cColor.r = Convert.ToSingle(row.Cells[11].Value);
                obj.m_cColor.g = Convert.ToSingle(row.Cells[12].Value);
                obj.m_cColor.b = Convert.ToSingle(row.Cells[13].Value);
                obj.m_cColor.a = Convert.ToSingle(row.Cells[14].Value);

                obj.m_cColorStep.r = Convert.ToSingle(row.Cells[15].Value);
                obj.m_cColorStep.g = Convert.ToSingle(row.Cells[16].Value);
                obj.m_cColorStep.b = Convert.ToSingle(row.Cells[17].Value);
                obj.m_cColorStep.a = Convert.ToSingle(row.Cells[18].Value);

                obj.m_fColorChangeStartTime = (float)row.Cells[19].Value;
                obj.m_bAlphaBlending = Convert.ToInt32(row.Cells[20].Value);
                obj.m_nSrcBlend = (int)row.Cells[21].Value;
                obj.m_nDestBlend = (int)row.Cells[22].Value;
                obj.m_nTextureRenderState = (int)row.Cells[23].Value;
                obj.m_bLightMapUse = Convert.ToInt32(row.Cells[24].Value);
                obj.m_bLightMapAlphaBlending = Convert.ToInt32(row.Cells[25].Value);
                obj.m_nLightMapSrcBlend = (int)row.Cells[26].Value;
                obj.m_nLightMapDestBlend = (int)row.Cells[27].Value;
                obj.m_nLightMapRenderState = (int)row.Cells[28].Value;
                obj.m_bAnimationLoop = Convert.ToInt32(row.Cells[29].Value);
                obj.m_fStartTime = (float)row.Cells[30].Value;
                obj.m_fEndTime = (float)row.Cells[31].Value;
                obj.m_bObjectAnimationLoop = Convert.ToInt32(row.Cells[32].Value);
                obj.m_nColorLoop = (int)row.Cells[33].Value;
                obj.m_bUseEnvironmentLight = Convert.ToInt32(row.Cells[34].Value);
                obj.m_bAlphaTestEnble = Convert.ToInt32(row.Cells[35].Value);
                obj.m_nAlphaTestValue = (int)row.Cells[36].Value;
                obj.m_bZWriteEnable = Convert.ToInt32(row.Cells[37].Value);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Update Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void UpdateSprite(Sprite sprite, DataGridViewRow row)
        {
            char[] dummy = new char[20];
            string temp;

            try
            {
                sprite.dwProductID = (uint)row.Cells[0].Value;
                sprite.dwVersion = (uint)row.Cells[1].Value;
                sprite.dwEffectType = (uint)row.Cells[2].Value;

                temp = row.Cells[3].Value.ToString();
                for (int i = 0; i < temp.Length; i++) dummy[i] = temp[i];
                sprite.m_strName = dummy;

                sprite.m_nTextureVertexBufferType = (int)row.Cells[4].Value;
                sprite.m_fTextureSize = (float)row.Cells[5].Value;
                sprite.m_fVel = (float)row.Cells[6].Value;
                sprite.m_fTick = (float)row.Cells[7].Value;
                sprite.m_bZbufferEnable = Convert.ToInt32(row.Cells[8].Value);

                sprite.m_cColor.r = Convert.ToSingle(row.Cells[9].Value);
                sprite.m_cColor.g = Convert.ToSingle(row.Cells[10].Value);
                sprite.m_cColor.b = Convert.ToSingle(row.Cells[11].Value);
                sprite.m_cColor.a = Convert.ToSingle(row.Cells[12].Value);

                sprite.m_cColorStep.r = Convert.ToSingle(row.Cells[13].Value);
                sprite.m_cColorStep.g = Convert.ToSingle(row.Cells[14].Value);
                sprite.m_cColorStep.b = Convert.ToSingle(row.Cells[15].Value);
                sprite.m_cColorStep.a = Convert.ToSingle(row.Cells[16].Value);

                sprite.m_fColorChangeStartTime = (float)row.Cells[17].Value;
                sprite.m_bAlphaBlending = Convert.ToInt32(row.Cells[18].Value);

                dummy = new char[20];
                temp = row.Cells[19].Value.ToString();
                for (int i = 0; i < temp.Length; i++) dummy[i] = temp[i];
                sprite.m_strTextureFile = dummy;

                sprite.m_nSrcBlend = (int)row.Cells[20].Value;
                sprite.m_nDestBlend = (int)row.Cells[21].Value;
                sprite.m_nTextureRenderState = (int)row.Cells[22].Value;
                sprite.m_bLightMapAlphaBlending = Convert.ToInt32(row.Cells[23].Value);

                dummy = new char[20];
                temp = row.Cells[24].Value.ToString();
                for (int i = 0; i < temp.Length; i++) dummy[i] = temp[i];
                sprite.m_strLightMapFile = dummy;

                sprite.m_nLightMapSrcBlend = (int)row.Cells[25].Value;
                sprite.m_nLightMapDestBlend = (int)row.Cells[26].Value;
                sprite.m_nLightMapRenderState = (int)row.Cells[27].Value;
                sprite.m_nColorLoop = (int)row.Cells[28].Value;
                sprite.m_bZWriteEnable = Convert.ToInt32(row.Cells[29].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void UpdateParticle(Particle particle, DataGridViewRow row, DataGridViewRow row_texturename)
        {
            char[] dummy = new char[20];
            string temp;

            try
            {
                particle.dwProductID = (uint)row.Cells[0].Value;
                particle.dwVersion = (uint)row.Cells[1].Value;
                particle.dwEffectType = (uint)row.Cells[2].Value;

                temp = row.Cells[3].Value.ToString();
                for (int i = 0; i < temp.Length; i++)
                    dummy[i] = temp[i];
                particle.m_strName = dummy;

                particle.m_bLoop = Convert.ToInt32(row.Cells[4].Value);
                particle.m_fDelayTime = (float)row.Cells[5].Value;
                particle.m_fCurrentDelayTime = (float)row.Cells[6].Value;
                particle.m_dwDestBlend = (uint)row.Cells[7].Value;
                particle.m_dwSrcBlend = (uint)row.Cells[8].Value;
                particle.m_nEmitMass = (int)row.Cells[9].Value;
                particle.m_fEmitTime = (float)row.Cells[10].Value;
                particle.m_fCurrentEmitTime = (float)row.Cells[11].Value;
                particle.m_fGravity = (float)row.Cells[12].Value;
                particle.m_fEmitLifeTime = (float)row.Cells[13].Value;
                particle.m_fCurrentEmitLifeTime = (float)row.Cells[14].Value;
                particle.m_fParticleLifeTime = (float)row.Cells[15].Value;

                particle.m_cStartColor.r = Convert.ToSingle(row.Cells[16].Value);
                particle.m_cStartColor.g = Convert.ToSingle(row.Cells[17].Value);
                particle.m_cStartColor.b = Convert.ToSingle(row.Cells[18].Value);
                particle.m_cStartColor.a = Convert.ToSingle(row.Cells[19].Value);

                particle.m_cColorVel.r = Convert.ToSingle(row.Cells[20].Value);
                particle.m_cColorVel.g = Convert.ToSingle(row.Cells[21].Value);
                particle.m_cColorVel.b = Convert.ToSingle(row.Cells[22].Value);
                particle.m_cColorVel.a = Convert.ToSingle(row.Cells[23].Value);

                particle.m_vPos.x = Convert.ToSingle(row.Cells[24].Value);
                particle.m_vPos.y = Convert.ToSingle(row.Cells[25].Value);
                particle.m_vPos.z = Convert.ToSingle(row.Cells[26].Value);

                particle.m_vVel.x = Convert.ToSingle(row.Cells[27].Value);
                particle.m_vVel.y = Convert.ToSingle(row.Cells[28].Value);
                particle.m_vVel.z = Convert.ToSingle(row.Cells[29].Value);

                particle.m_fTextureSizeVel = (float)row.Cells[30].Value;
                particle.m_fTextureStartSize = (float)row.Cells[31].Value;
                particle.m_fTextureSizeMax = (float)row.Cells[32].Value;
                particle.m_fTextureSizeMin = (float)row.Cells[33].Value;
                particle.m_fTick = (float)row.Cells[34].Value;
                particle.m_nTextureSizeChangeType = (int)row.Cells[35].Value;
                particle.m_fCurrentTick = (float)row.Cells[36].Value;

                particle.m_vDir.x = Convert.ToSingle(row.Cells[37].Value);
                particle.m_vDir.y = Convert.ToSingle(row.Cells[38].Value);
                particle.m_vDir.z = Convert.ToSingle(row.Cells[39].Value);

                particle.m_vArea.x = Convert.ToSingle(row.Cells[40].Value);
                particle.m_vArea.y = Convert.ToSingle(row.Cells[41].Value);
                particle.m_vArea.z = Convert.ToSingle(row.Cells[42].Value);

                particle.m_bCreateRandom = Convert.ToInt32(row.Cells[43].Value);
                particle.m_fCircleForce = (float)row.Cells[44].Value;
                particle.m_fCreateDensity = (float)row.Cells[45].Value;
                particle.m_fEmitRadius = (float)row.Cells[46].Value;
                particle.m_fRotateAngle = (float)row.Cells[47].Value;
                particle.m_fTextureAnimationTime = (float)row.Cells[48].Value;
                particle.m_nEmitterType = (int)row.Cells[49].Value;
                particle.m_nTextureAnimationType = (int)row.Cells[50].Value;
                particle.m_nParticleType = (int)row.Cells[51].Value;
                particle.m_fEmitAngle = (float)row.Cells[52].Value;
                particle.m_nTextureNumber = (int)row.Cells[53].Value;

                for (int i = 0; i < 20; i++)
                {
                    temp = row_texturename.Cells[i].Value.ToString();
                    for (int j = 0; j < temp.Length; j++)
                        particle.m_strTextureName[i, j] = temp[j];
                }

                particle.m_nPersistence = (int)row.Cells[54].Value;
                particle.m_bZbufferEnable = Convert.ToInt32(row.Cells[55].Value);
                particle.m_fColorChangeStartTime = (float)row.Cells[56].Value;
                particle.m_nColorLoop = (int)row.Cells[57].Value;
                particle.m_nObjCreateTargetType = (int)row.Cells[58].Value;
                particle.m_nObjCreateUpType = (int)row.Cells[59].Value;
                particle.m_nObjMoveTargetType = (int)row.Cells[60].Value;
                particle.m_bZWriteEnable = Convert.ToInt32(row.Cells[61].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void UpdateTrace(Trace trace, DataGridViewRow row, DataGridViewRow row_texturename)
        {
            char[] dummy = new char[20];
            string temp;

            try
            {
                trace.dwProductID = (uint)row.Cells[0].Value;
                trace.dwVersion = (uint)row.Cells[1].Value;
                trace.dwEffectType = (uint)row.Cells[2].Value;
                trace.dwType = (uint)row.Cells[3].Value;
                trace.fDistance = (float)row.Cells[4].Value;

                temp = row.Cells[5].Value.ToString();
                for (int i = 0; i < temp.Length; i++)
                    dummy[i] = temp[i];
                trace.m_strName = dummy;

                trace.m_nNumberOfTrace = (uint)row.Cells[6].Value;
                trace.m_fCreateTick = (float)row.Cells[7].Value;
                trace.m_fHalfSize = (float)row.Cells[8].Value;
                trace.m_nTextureNumber = (uint)row.Cells[9].Value;
                trace.m_fTextureAnimationTime = (float)row.Cells[10].Value;

                for (int i = 0; i < 20; i++)
                {
                    temp = row_texturename.Cells[i].Value.ToString();
                    for (int j = 0; j < temp.Length; j++)
                            trace.m_strTextureName[i, j] = temp[j];
                }

                trace.m_nNumberOfCross = (int)row.Cells[11].Value;
                trace.m_bAlphaBlendEnable = Convert.ToInt32(row.Cells[12].Value);
                trace.m_dwSrcBlend = (uint)row.Cells[13].Value;
                trace.m_dwDestBlend = (uint)row.Cells[14].Value;
                trace.m_nTextureRenderState = (uint)row.Cells[15].Value;
                trace.m_bZbufferEnable = Convert.ToInt32(row.Cells[16].Value);
                trace.m_bZWriteEnable = Convert.ToInt32(row.Cells[17].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion
    }
}
