var v = new Vue({
    el: '#app',
    data: {
        user: "",
        ui: [],
        iframeSrc: "/MyHome/Index",
        lastIframeSrc: {
            name: "",
            src: "",
        },
        menuList: {
            用户管理: "/UserMgr/Index",
            角色管理: "http://www.baidu.com",
            企业周报: "/Weekly/Index",
            审批事项: "/Apply/Index",
            个人主页: "/MyHome/Index",
        },
        activeFromName: "个人主页",
    },
    watch: {
        'iframeSrc': function () {

        }
    },
    computed: {
        lastName: function () {
            var str = this.ui.UName;
            if ("undefined" != typeof str) {
                var n = str.split("");
                return n[n.length - 1]
            }

        }
    },
    methods: {
        getActiveUInfo: function () {
            this.$http.post("/Home/ActiveUserInfo").then(response => {
                this.ui = response.body.ui;
            }, function () {
                alert("请求失败");
            })
        },
        test: function (name) {
            if (name == "logout") {
                window.location.href = "/Home/Logout";
            }
            this.lastIframeSrc.name = this.activeFromName;
            this.lastIframeSrc.src = this.iframeSrc;
            this.iframeSrc = this.menuList[name];
            this.activeFromName = name;
        },
        goLastPage: function () {
            let newname = this.lastIframeSrc.name
                    /*this.lastIframeSrc.name*/  let lastsrc = this.activeFromName;
                   /* this.lastIframeSrc.src*/ let lastname = this.iframeSrc;
            this.iframeSrc = this.lastIframeSrc.src;
            this.lastIframeSrc.name = lastsrc;
            this.lastIframeSrc.src = lastname;
            this.activeFromName = newname;


        },
    },
    created: function () {
        this.getActiveUInfo();

    },

})