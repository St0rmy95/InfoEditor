using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoEditor.ObjectInfo.Data
{
    using static InfoEditor.Global.D3D9Types;
    using BOOL = System.Int32;

    public static class OBJECTData
    {
        public static char[] m_strCharacterFileName = new char[20];
        public static int m_nBodyConditionNumber;
        public static Dictionary<UInt64, BodyConditionData> data = new Dictionary<UInt64, BodyConditionData>();
    }


    public class BodyConditionData 
    {
        public UInt64 m_nBodyCondition;
        public char[] m_strBodyConditionName = new char[20];
        public BOOL m_bCharacterAlphaBlending;
        public int m_nCharacterTextureRenderState;
        public int m_nCharacterDestBlend;
        public int m_nCharacterSrcBlend;
        public int m_nEffectNumber;
        public float m_fStartAnimationTime;
        public float m_fEndAnimationTime;
        public BOOL m_bCharacterRendering;
        public BOOL m_bNotAnimationLooping;
        public float m_fAnimationVel;
        public char[] m_strSoundFileName = new char[20];

        //  -- CBodyConditionInfo --
        public List<_EffectInfo> m_vecEffect = new List<_EffectInfo>();
    }

    public class _EffectInfo
    {
        public int m_nEffectType;
        public char[] m_strEffectName = new char[20];
        public D3DXVECTOR3 m_vPos = new D3DXVECTOR3();
        public D3DXVECTOR3 m_vTarget = new D3DXVECTOR3();
        public D3DXVECTOR3 m_vUp = new D3DXVECTOR3();
        public float m_fStartTime;
        public BOOL m_bUseBillboard;
        public float m_fBillboardAngle;
        public float m_fBillboardRotateAngle;
        public float m_fBillboardRotatePerSec;
        public float m_fRandomUpLargeAngle;
        public float m_fRandomUpSmallAngle;
        public BOOL m_bUseCharacterMatrix;
        public BOOL m_bGroundBillboard;

        public _EffectInfo() { return; }
    }

}
