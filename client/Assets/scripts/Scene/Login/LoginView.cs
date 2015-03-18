using Core.MVC;
//using Cotg.Scene;
using Cotg.UI.Login;
//using Cotg.Battle.Managers;

public class LoginView : View
{
    ///// <summary>
    ///// 账号
    ///// </summary>
    //public UIInput m_account;
    ///// <summary>
    ///// 密码
    ///// </summary>
    //public UIInput m_password;
    
    ///// <summary>
    ///// 显示状态
    ///// </summary>
    //public UILabel m_showState;

#region  mono 调用
    void Start()
    {
       Init(LoginManager.GetInstance().Model);
       OnButtonCommit();
    }

    public void OnButtonCommit()
    {
        LoginSerives.GetInstance().Login("ssss","1234");
    }
#endregion

    #region  父类方法

    public override void Init(Model model)
    {
        base.Init(model);
        BindModel(LoginModel.AttEnum.PASSWORDCHANGE,__ChangePlayerId);
        BindModel(LoginModel.AttEnum.NAMECHANGE,__ChangeName);
    }

    private void __ChangePlayerId(object[] argObjects)
    {
        //m_showState.text += argObjects[0] + "";
    }

    private void __ChangeName(object[] argObjects)
    {
        //m_showState.text += argObjects[0] + "";
    }

    #endregion
}
