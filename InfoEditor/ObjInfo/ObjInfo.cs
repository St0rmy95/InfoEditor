using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfoEditor.Global;
using InfoEditor.ObjectInfo.Data;

namespace InfoEditor.ObjectInfo
{
    public class ObjInfo
    {

        public void ReadBodyConditionData()
        {             
            using (BinaryReader br = new BinaryReader(new FileStream(GlobalValues.FilePath, FileMode.Open)))
            {
                OBJECTData.m_strCharacterFileName =                                      Encoding.UTF8.GetChars(br.ReadBytes(20));
                OBJECTData.m_nBodyConditionNumber =                                      br.ReadInt32();

                for (int i = 0; i < OBJECTData.m_nBodyConditionNumber; i++)
                {
                    BodyConditionData dummy_BodyConditionData = new BodyConditionData();

                    dummy_BodyConditionData.m_nBodyCondition =                        br.ReadUInt64();
                    dummy_BodyConditionData.m_strBodyConditionName =                  Encoding.UTF8.GetChars(br.ReadBytes(20));
                    dummy_BodyConditionData.m_bCharacterAlphaBlending =               br.ReadInt32();
                    dummy_BodyConditionData.m_nCharacterTextureRenderState =          br.ReadInt32();
                    dummy_BodyConditionData.m_nCharacterDestBlend =                   br.ReadInt32();
                    dummy_BodyConditionData.m_nCharacterSrcBlend =                    br.ReadInt32();
                    dummy_BodyConditionData.m_nEffectNumber =                         br.ReadInt32();
                    dummy_BodyConditionData.m_fStartAnimationTime =                   br.ReadSingle();
                    dummy_BodyConditionData.m_fEndAnimationTime =                     br.ReadSingle();
                    dummy_BodyConditionData.m_bCharacterRendering =                   br.ReadInt32();
                    dummy_BodyConditionData.m_bNotAnimationLooping =                  br.ReadInt32();
                    dummy_BodyConditionData.m_fAnimationVel =                         br.ReadSingle();
                    dummy_BodyConditionData.m_strSoundFileName =                      Encoding.UTF8.GetChars(br.ReadBytes(20));

                    dummy_BodyConditionData.m_vecEffect.Clear();
                    for (int j = 0;  j < dummy_BodyConditionData.m_nEffectNumber; j++)
                    {
                        _EffectInfo dummy_EffectInfo = new _EffectInfo();

                        dummy_EffectInfo.m_nEffectType =            br.ReadInt32();
                        dummy_EffectInfo.m_strEffectName =          Encoding.UTF8.GetChars(br.ReadBytes(20));
                        dummy_EffectInfo.m_vPos.set(
                            br.ReadSingle(),
                            br.ReadSingle(),
                            br.ReadSingle());
                        dummy_EffectInfo.m_vTarget.set(
                            br.ReadSingle(),
                            br.ReadSingle(),
                            br.ReadSingle());
                        dummy_EffectInfo.m_vUp.set(
                            br.ReadSingle(),
                            br.ReadSingle(),
                            br.ReadSingle());
                        dummy_EffectInfo.m_fStartTime =             br.ReadSingle();
                        dummy_EffectInfo.m_bUseBillboard =          br.ReadInt32();
                        dummy_EffectInfo.m_fBillboardAngle =        br.ReadSingle();
                        dummy_EffectInfo.m_fBillboardRotateAngle =  br.ReadSingle();
                        dummy_EffectInfo.m_fBillboardRotatePerSec = br.ReadSingle();
                        dummy_EffectInfo.m_fRandomUpLargeAngle =    br.ReadSingle();
                        dummy_EffectInfo.m_fRandomUpSmallAngle =    br.ReadSingle();
                        dummy_EffectInfo.m_bUseCharacterMatrix =    br.ReadInt32();
                        dummy_EffectInfo.m_bGroundBillboard =       br.ReadInt32();

                        dummy_BodyConditionData.m_vecEffect.Add(dummy_EffectInfo);
                    }
                    OBJECTData.data[dummy_BodyConditionData.m_nBodyCondition] = dummy_BodyConditionData;
                }
            }
        }
        
        public void WriteBodyConditionData()
        {
            using (BinaryWriter br = new BinaryWriter(new FileStream(GlobalValues.FilePath, FileMode.Create)))
            {
                br.Write(OBJECTData.m_strCharacterFileName);
                br.Write(OBJECTData.m_nBodyConditionNumber);
                foreach (var n in OBJECTData.data)
                {
                    br.Write(n.Value.m_nBodyCondition);
                    br.Write(n.Value.m_strBodyConditionName);
                    br.Write(n.Value.m_bCharacterAlphaBlending);
                    br.Write(n.Value.m_nCharacterTextureRenderState);
                    br.Write(n.Value.m_nCharacterDestBlend);
                    br.Write(n.Value.m_nCharacterSrcBlend);
                    br.Write(n.Value.m_nEffectNumber);
                    br.Write(n.Value.m_fStartAnimationTime);
                    br.Write(n.Value.m_fEndAnimationTime);
                    br.Write(n.Value.m_bCharacterRendering);
                    br.Write(n.Value.m_bNotAnimationLooping);
                    br.Write(n.Value.m_fAnimationVel);
                    br.Write(n.Value.m_strSoundFileName);

                    for (int i = 0; i < n.Value.m_nEffectNumber; i++)
                    {
                        br.Write(n.Value.m_vecEffect[i].m_nEffectType);
                        br.Write(n.Value.m_vecEffect[i].m_strEffectName);
                        br.Write(n.Value.m_vecEffect[i].m_vPos.x);
                        br.Write(n.Value.m_vecEffect[i].m_vPos.y);
                        br.Write(n.Value.m_vecEffect[i].m_vPos.z);
                        br.Write(n.Value.m_vecEffect[i].m_vTarget.x);
                        br.Write(n.Value.m_vecEffect[i].m_vTarget.y);
                        br.Write(n.Value.m_vecEffect[i].m_vTarget.z);
                        br.Write(n.Value.m_vecEffect[i].m_vUp.x);
                        br.Write(n.Value.m_vecEffect[i].m_vUp.y);
                        br.Write(n.Value.m_vecEffect[i].m_vUp.z);
                        br.Write(n.Value.m_vecEffect[i].m_fStartTime);
                        br.Write(n.Value.m_vecEffect[i].m_bUseBillboard);
                        br.Write(n.Value.m_vecEffect[i].m_fBillboardAngle);
                        br.Write(n.Value.m_vecEffect[i].m_fBillboardRotateAngle);
                        br.Write(n.Value.m_vecEffect[i].m_fBillboardRotatePerSec);
                        br.Write(n.Value.m_vecEffect[i].m_fRandomUpLargeAngle);
                        br.Write(n.Value.m_vecEffect[i].m_fRandomUpSmallAngle);
                        br.Write(n.Value.m_vecEffect[i].m_bUseCharacterMatrix);
                        br.Write(n.Value.m_vecEffect[i].m_bGroundBillboard);
                    }
                }
            }
        }
    }
}
