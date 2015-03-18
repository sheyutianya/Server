using System;
using System.Collections.Generic;
using Core.MVC;

namespace Cotg.UI.Login
{
    public class LoginModel : Model
    {
        #region  model 注入的属性

        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    Refresh(AttEnum.NAMECHANGE, _Name);
                }
                ;
            }
        }

        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    Refresh(AttEnum.PASSWORDCHANGE, _Password);
                }
                ;
            }
        }

        private string _Password;
        public string _Name;

        #endregion


        #region 批量更新

        //需要更新的字段
        public enum AttEnum
        {
            PASSWORDCHANGE,
            NAMECHANGE
        }

        #endregion

    }
}
