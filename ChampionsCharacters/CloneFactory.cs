using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Champions.Characters;

namespace Champions
{
    public class CloneFactory
    {
        static CloneFactory _instance;
        static Dictionary<string, Characters.Characteristics> _baseCharacteristics;
        private CloneFactory() { Load(); }

        private static CloneFactory GetInstance()
        {
            if (_instance == null)
                _instance = new CloneFactory();

            return _instance;
        }

        public static  Characteristics GetCharacteristicSet(string key)
        {
            GetInstance();
            return _baseCharacteristics[key];
        }

        static private void Load()
        {
            LoadCharacteristics();
        }

        /// <summary>
        /// Creates the prototypes for different characteristic sets.
        /// For new sections, data[0] is the key name and data[1:3] are empty
        /// For each characteristic, data[0] is the name, data[1] is the base value, data[2] is the amount the value increases, data[3] is the amount of cp it costs for the next point
        /// Each section is separate by four empty commas
        /// </summary>
        static private void LoadCharacteristics()
        {
            StreamReader reader = new StreamReader("..\\..\\Properties\\BaseCharacteristics.csv");
            _baseCharacteristics = new Dictionary<string, Characters.Characteristics>();
            Characters.Characteristics blueprint = null;
            reader.ReadLine();
            string key = "";

            while(!reader.EndOfStream)
            {
                string[] data = reader.ReadLine().Split(',');
                if (data[0].Length == 0)
                {
                    _baseCharacteristics.Add(key, blueprint);
                    blueprint = null;
                    continue;
                }
                else if (data[1].Length == 0)
                {
                    key = data[0];
                    continue;
                }
                else if (blueprint == null)
                    blueprint = new Characters.Characteristics(key);

                Characters.Characteristic c = new Characters.Characteristic(data[0], int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), bool.Parse(data[4]), int.Parse(data[5]));
                blueprint.AddCharacteristic(c);
                
            }
        }
    }
}
