using REFEstoqueDotNetV3.system;

namespace REFEstoqueDotNetV3.model
{
    public abstract class BaseModel
    {
        //status dos dados do bean
        private DataStatus _dataStatus;

        public DataStatus dataStatus
        {
            get { return _dataStatus; }
            set { _dataStatus = value; }
        }
    }
}
