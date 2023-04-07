using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Formats.Asn1;
using System.Text.Json;
using Microsoft.Extensions.Options;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text.Json.Serialization;

namespace DbOperations.ResponseObject
{
    public class ResponseObjectConverter<T> : JsonConverter<ResponseObject<T>>
    {
        public override ResponseObject<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, ResponseObject<T> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("code", value._code.GetStringValue() );
            writer.WriteString("message", value._message);
            writer.WritePropertyName("data");
            JsonSerializer.Serialize(writer, value._data, options);
            writer.WriteEndObject();
        }
    }

    [JsonConverter(typeof(ResponseObjectConverter<>))]
    public class ResponseObject<T>
    {
        public T _data;
        public ResultCode _code;
        public String _message;

        public ResponseObject()
        {

        }

        public ResponseObject(T data)
        {
            _data = data;
        }

        public T GetResponseData()
        {
            return _data;
        }

        ResultCode GetResultCode()
        {
            return _code;
        }

        public void SetResponeData(T data, ResultCode code, String message)
        {
            _code = code;
            _data = data;
            _message = message;
        }


    }
}
