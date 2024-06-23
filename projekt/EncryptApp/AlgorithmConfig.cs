using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptApp
{
    [Serializable]
    public class AlgorithmConfig
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string IV { get; set; }
    }
}
