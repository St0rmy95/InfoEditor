using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InfoEditor.Global
{    
    public static class D3D9Types
    {
        public class D3DXCOLOR
        {
            public float r, g, b, a;
            public D3DXCOLOR(float r, float g, float b, float a)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }
            public D3DXCOLOR()
            {
                return;
            }

            public void set(float r, float g, float b, float a)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }
        }

        public class D3DXVECTOR3
        {
            public float x, y, z;
            public D3DXVECTOR3(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public D3DXVECTOR3()
            {
                return;
            }

            public void set(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
    }
}
