using InfoEditor.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoEditor.EffectInfo.Data
{
    using static InfoEditor.Global.D3D9Types;
    using BOOL = System.Int32;

    public class FileHeader
    {
        public uint dwProductID;
        public uint dwVersion;
        public uint dwEffectType;
    }

    // Object is all uppercase because of an issue with it fucking up other code
    // because of the same name Object (who would've thought :V)
    public class OBJECT : FileHeader
    {
        public char[] m_strName = new char[20];
        public char[] m_strObjectFile = new char[20];
        public float m_fScale;
        public int m_nObjectAniType;
        public float m_fTextureAniVel;
        public float m_fObjectAniVel;
        public float m_fTick;
        public BOOL m_bZbufferEnable;
        public D3DXCOLOR m_cColor = new D3DXCOLOR();
        public D3DXCOLOR m_cColorStep = new D3DXCOLOR();
        public float m_fColorChangeStartTime;
        public BOOL m_bAlphaBlending;
        public int m_nSrcBlend;
        public int m_nDestBlend;
        public int m_nTextureRenderState;
        public BOOL m_bLightMapUse;
        public BOOL m_bLightMapAlphaBlending;
        public int m_nLightMapSrcBlend;
        public int m_nLightMapDestBlend;
        public int m_nLightMapRenderState;
        public BOOL m_bAnimationLoop;
        public float m_fStartTime;
        public float m_fEndTime;
        public BOOL m_bObjectAnimationLoop;
        public int m_nColorLoop;
        public BOOL m_bUseEnvironmentLight;
        public BOOL m_bAlphaTestEnble;
        public int m_nAlphaTestValue;
        public BOOL m_bZWriteEnable;
    }

    public class Sprite : FileHeader
    {
        public char[] m_strName = new char[20];
        public int m_nTextureVertexBufferType;
        public float m_fTextureSize;
        public float m_fVel;
        public float m_fTick;
        public BOOL m_bZbufferEnable;
        public D3DXCOLOR m_cColor = new D3DXCOLOR();
        public D3DXCOLOR m_cColorStep = new D3DXCOLOR();
        public float m_fColorChangeStartTime;
        public BOOL m_bAlphaBlending;
        public char[] m_strTextureFile = new char[20];
        public int m_nSrcBlend;
        public int m_nDestBlend;
        public int m_nTextureRenderState;
        public BOOL m_bLightMapAlphaBlending;
        public char[] m_strLightMapFile = new char[20];
        public int m_nLightMapSrcBlend;
        public int m_nLightMapDestBlend;
        public int m_nLightMapRenderState;
        public int m_nColorLoop;
        public BOOL m_bZWriteEnable;
    }

    public class Particle : FileHeader
    {
        public char[] m_strName = new char[20];
        public BOOL m_bLoop;
        public float m_fDelayTime;
        public float m_fCurrentDelayTime;
        public uint m_dwDestBlend;
        public uint m_dwSrcBlend;
        public int m_nEmitMass;
        public float m_fEmitTime;
        public float m_fCurrentEmitTime;
        public float m_fGravity;
        public float m_fEmitLifeTime;
        public float m_fCurrentEmitLifeTime;
        public float m_fParticleLifeTime;
        public D3DXCOLOR m_cStartColor = new D3DXCOLOR();
        public D3DXCOLOR m_cColorVel = new D3DXCOLOR();
        public D3DXVECTOR3 m_vPos = new D3DXVECTOR3();
        public D3DXVECTOR3 m_vVel = new D3DXVECTOR3();
        public float m_fTextureSizeVel;
        public float m_fTextureStartSize;
        public float m_fTextureSizeMax;
        public float m_fTextureSizeMin;
        public float m_fTick;
        public int m_nTextureSizeChangeType;
        public float m_fCurrentTick;
        public D3DXVECTOR3 m_vDir = new D3DXVECTOR3();
        public D3DXVECTOR3 m_vArea = new D3DXVECTOR3();
        public BOOL m_bCreateRandom;
        public float m_fCircleForce;
        public float m_fCreateDensity;
        public float m_fEmitRadius;
        public float m_fRotateAngle;
        public float m_fTextureAnimationTime;
        public int m_nEmitterType;
        public int m_nTextureAnimationType;
        public int m_nParticleType;
        public float m_fEmitAngle;
        public int m_nTextureNumber;
        public char[,] m_strTextureName = new char[20, 20];
        public int m_nPersistence;
        public BOOL m_bZbufferEnable;
        public float m_fColorChangeStartTime;
        public int m_nColorLoop;
        public int m_nObjCreateTargetType;
        public int m_nObjCreateUpType;
        public int m_nObjMoveTargetType;
        public BOOL m_bZWriteEnable;
    }
    public class Trace : FileHeader
    {
        public uint dwType;
        public float fDistance;
        public char[] m_strName = new char[20];
        public uint m_nNumberOfTrace;
        public float m_fCreateTick;
        public float m_fHalfSize;
        public uint m_nTextureNumber;
        public float m_fTextureAnimationTime;
        public char[,] m_strTextureName = new char[20, 20];
        public int m_nNumberOfCross;
        public BOOL m_bAlphaBlendEnable;
        public uint m_dwSrcBlend;
        public uint m_dwDestBlend;
        public uint m_nTextureRenderState;
        public BOOL m_bZbufferEnable;
        public BOOL m_bZWriteEnable;
    }
}
