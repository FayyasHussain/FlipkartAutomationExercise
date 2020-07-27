using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Flipkart.Automation.Core
{
    public static class JsonHelper
    {
        internal class JsonPascalTextReader : JsonTextReader
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="JsonPascalTextReader"/> class.
            /// </summary>
            /// <param name="reader">The <c>TextReader</c> containing the XML data to read.</param>
            public JsonPascalTextReader(TextReader reader) : base(reader)
            {
            }

            
            public override object Value
            {
                get
                {
                    if (this.TokenType == JsonToken.PropertyName)
                    {
                        string value = base.Value.ToString().ToPascalCase();
                        return value;
                    }
                    else
                    {
                        return base.Value;
                    }
                }
            }
        }


        public static dynamic ReadJsonTestData(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                return DeserializeObject(jsonData, null);
            }

            return null;
        }
        public static object DeserializeObject(string value, Type type)
        {
            using (JsonReader jsonTextReader = new JsonPascalTextReader(new StringReader(value)))
            {
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault();
                return jsonSerializer.Deserialize(jsonTextReader, type);
            }
        }
    }
}
