using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoEditor.Global
{
    public static class Defines
    {
        public const int OBJECTINFO_OBJECT = 4;
        public const int EFFECTINFO_OBJECT = 0;
        public const int SPRITE = 1;
        public const int PARTICLE = 2;
        public const int TRACE = 3;
    }

    public static class GlobalValues
    {
        public static int EffectType { get; set; }
        public static string FilePath { get; set; }
        public static bool FileOpened { get; set; }
        public static bool FileSaved { get; set; }
        public static Form CurrentForm { get; set; }
        public static ulong CurrentBodyCondition { get; set; }
    } 
}
