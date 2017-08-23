function checkformname() {
    var regname = /^\w{5,20}$/;
    var fname = document.getElementById("Uname");
    if (fname.value == "" || fname.value.length < 5 || fname.value.length > 20) {
        fname.value = "";
    }
    else {
        if (fname.value.match(regname)) {
        }
        else {
            fname.value = "";
        }
    }
}
function checkpassword() {
    var regpass = /^\w{4,20}$/;
    var fpwd = document.getElementById("Upass");
    if (fpwd.value == "" || fpwd.value.length < 4 || fpwd.value.length > 20) {
        fpwd.value = "";
    }
    else {
        if (fpwd.value.match(regpass)) {
        }
        else {
            fpwd.value = "";
        }
    }
}
function recheckpassword() {
    var fpwd = document.getElementById("Upass");
    var frpwd = document.getElementById("Uconfigpass");
    if (frpwd.value != fpwd.value) {
        frpwd.value = "";
    }
}
function checkrole() {
    var frole = document.getElementById("Urole");
    if (frole.value == 0 || frole.value == 1) {
    }
    else {
        frole.value = "";
    }
}
function checkphone() {
    var regphone = /0?(13|15|17|18)[0-9]{9}/;
    var fphone = document.getElementById("Uphone");
    if (fphone.value == "") {
    }
    else {
        if (fphone.value.match(regphone)) {
        }
        else {
            fphone.value = "";
        }
    }
}
function checkemail() {
    var regemail = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*(;\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*$/;
    var femail = document.getElementById("Uemail");
    if (femail.value == "") {
    }
    else {
        if (femail.value.match(regemail)) {
        }
        else {
            femail.value = "";
        }
    }
}
$(function () {
    $("#UsubmitBtn").click(function () {
        var Uname = $('#Uname').val();
        var Upass = $('#Upass').val();
        var Uconfigpass = $('#Uconfigpass').val();
        var Urole = $('#Urole').val();
        var Uphone = $('#Uphone').val();
        var Uemail = $('#Uemail').val();
        var Udepartment = $('#Udepartment').val();
        /*if (Upass != Uconfigpass) {
            alert("请重新确认密码！");
        }*/
        var Udata = {
            Uname: Uname,
            Upass: Upass,
            Urole: Urole,
            Uphone: Uphone,
            Uemail: Uemail,
            Udepartment :Udepartment 
        };
        $.ajax({
            type: 'post',
            url: "../Handler/register.ashx?action=register",
            data: Udata,
            success: function (Udata) {
                if (Udata == "True") {
                    alert("注册成功！");
                    self.location = "homepage.html";
                }
                else {
                    alert("注册失败！");
                    self.location = "register.html";
                }
            }
        })
    });

   
});