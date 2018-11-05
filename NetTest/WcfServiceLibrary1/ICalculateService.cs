using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculateService" in both code and config file together.

    //WCF服务至少需要2个契约,一个服务契约,一个操作契约,WCF服务不能单独存在,必须要有一个宿主,宿主可以是web,可以是服务,可以是application.
    //wcf有3部分组成,宿主,服务契约,操作契约


    //服务契约
    [ServiceContract(Name = "CalculateService")]
    public interface ICalculateService
    {
        //以下都是操作契约
        [OperationContract(Name = "AddOperation")]
        double AddOperation(double num1, double num2);

        [OperationContract(Name = "SubOperation")]
        double SubOperation(double num1, double num2);

        [OperationContract(Name = "MulOperation")]
        double MulOperation(double num1, double num2);

        [OperationContract(Name = "DivOperation")]
        double DivOperation(double num1, double num2);
        
    }
}
