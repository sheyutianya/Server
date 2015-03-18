using System;
using System.Reflection;

namespace Core.MVC
{
    public abstract class Model : Notifier
    {
        //模型名是只读的，只在构造函数处生成
        protected string _modelName;

        public string GetModelName()
        {
            if (string.IsNullOrEmpty(_modelName))
            {
                _modelName = this.GetHashCode().ToString();
            }
            return _modelName;
        }

        public bool IsModelNameValide()
        {
            //如果不存在该模型名，该模型名可用
            return !HasEvent(_modelName);
        }

        // 将一个object注入到该数据模型
        public void Inject(object obj)
        {
            //1.获取obj的所有属性 
            //定义的  public 字段
            FieldInfo[] fields = obj.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                //2.检查自己是否拥有该属性
                FieldInfo myfield = this.GetType().GetField(field.Name);
                if (null != myfield)
                {
                    //3.设置值
                    myfield.SetValue(this, field.GetValue(obj));
                }
            }

            // 定义的 get set 属性
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                //2.检查自己是否拥有该属性
                PropertyInfo myProperty = this.GetType().GetProperty(property.Name);
                if (null != myProperty && myProperty.CanWrite)
                {
                    //3.设置值
                    myProperty.SetValue(this, property.GetValue(obj, null), null);
                }
            }
        }

        protected void Refresh(Enum attribute, params object[] e)
        {
            //触发事件并将被改变的属性作为参数传入
            RaiseEvent(_modelName + attribute, e);
        }

        public virtual void Destory()
        {
        }
    }
}
