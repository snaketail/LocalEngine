using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using _BaseClass.utils;


namespace _BaseClass
{
    [Serializable]
    public class MqttMessage<T> 
    {
        private string id;
        private string name;
        private string prefixCode;
        private long timestamp;
        private bool report = false;
        private MessageType type;
        private List<T> content;
        private int code;
        private string message;
        private long version;

        public MqttMessage()
        {
            this.id = UUIDUtil.timeBasedUUID().ToString();
            this.timestamp = (DateTime.UtcNow.Ticks)/10000;
            this.content = new List<T>();
            this.version = 0;


        }

        public String getId()
        {
            return id;
        }

        public void setId(String id)
        {
            this.id = id;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getPrefixCode()
        {
            return prefixCode;
        }

        public void setPrefixCode(String prefixCode)
        {
            this.prefixCode = prefixCode;
        }

        public long getTimestamp()
        {
            return timestamp;
        }

        public void setTimestamp(long timestamp)
        {
            this.timestamp = timestamp;
        }

        public bool isReport()
        {
            return report;
        }

        public void setReport(bool report)
        {
            this.report = report;
        }

        public MessageType getType()
        {
            return type;
        }

        public void setType(MessageType type)
        {
            this.type = type;
        }

        public List<T> getContent()
        {
            return content;
        }

        public void setContent(List<T> content)
        {
            this.content = content;
        }

        public int getCode()
        {
            return code;
        }

        public void setCode(int code)
        {
            this.code = code;
        }

        public String getMessage()
        {
            return message;
        }

        public void setMessage(String message)
        {
            this.message = message;
        }

        public long getVersion()
        {
            return version;
        }

        public void setVersion(long version)
        {
            this.version = version;
        }
    }
}
