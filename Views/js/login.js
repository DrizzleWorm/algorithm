$(function () {
    $("#submitBtn").click(function () {
        var username = $('#username').val();
        var password = $('#password').val();
        if (username == null || username=="" || username==undefined) {
            alert("用户名不能为空！");
            self.location = "login.html";
            return false;
        }
        if (password == null || password == "" || password == undefined) {
            alert("密码不能为空！");
            self.location = "login.html";
            return false;
        }
        var data = {
            username: username,
            password: password,
        };
        $.ajax({
            type: 'post',
            url: "../Handler/login.ashx?",
            data: data,
            success: function (data) {
                if (data == "1") {
                    alert("登录成功！");
                    self.location = "homepage.html";
                }
                else {
                    alert("用户名或密码错误，请重新输入！");
                    self.location = "login.html";
                    return false;
                }
            }
        })
    });
});
/*var username = $("#username").val(); //获取用户名
   var pwd = $("#password").val(); //获取密码
   //if (username != undefined) {
   $.post("../Handler/login.ashx", { Username: username, Password: pwd, OP: "login" }, function (data) {
       if (data == "True") {
           alert("登录成功！");
           self.location = "homepage.html";
       }
       else
      {
           alert("用户名或密码错误！");
           return false;
       }*/
            //alert(data);
       

       //}
        /*else {
            alert("请输入用户名！");
            return false;
        }*/
    //    var postData = {
    //        Username: username,
    //        Password: pwd,
    //        OP:'login'
    //    }
    //    $.ajax({
    //        Type: 'post',
    //        url:"../Handler/login.ashx",
    //        data: postData,
    //        dataType: 'json',
    //        success: function (data) {
    //            alert(data);
    //            //self.location = "homepage.html";
    //        }
    //    })
    //});
