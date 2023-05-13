using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Boss.DatabaseNamespace {
    public static class JsonHandling {

        public static string path = "C:\\Users\\Public\\Downloads\\";

        public static void WriteData<T>(T? list, string filename) {
            JsonSerializerOptions op = new JsonSerializerOptions();
            op.WriteIndented = true;

            File.WriteAllText(path + filename + ".json", JsonSerializer.Serialize(list, op));
        }

        public static List<T> ReadData<T>(string filename) {
            JsonSerializerOptions op = new JsonSerializerOptions();
            op.WriteIndented = true;
            using FileStream fs = new FileStream(path + filename + ".json", FileMode.Open);

            List<T>? readData = JsonSerializer.Deserialize<List<T>>(fs, op);
            return readData!;
        }
    }
}
