
    var vtable = new Vue({
        el: '#UserTable',
        data: {
        columns7: [
                {
        title: '姓名',
    key: 'UName',
                    render: (h, params) => {
                        return h('div', [
                            h('Icon', {
        props: {
        type: 'person'
}
}),
h('strong', params.row.UName)
]);
}
},
                {
        title: '部门',
    key: 'DepName'
},
                {
        title: '角色',
    key: 'RName'
},
                {
        title: '账号状态',
    key: 'DelFlag',
                    render: (h, params) => {
        let _this = this;
    let _val = "";
    var color = "";
                        if (params.row.DelFlag == 1) {
        _val = "已禁用";
    color = "crimson"
                        } else if (params.row.DelFlag == 0) {
        _val = "正常";
    color = "Black"
}
                        return h('div', {
        props: {

    },
                            attrs: {

        style: `margin-left:10px;color:${color}`,

},
}, _val);
}
},
                {
        title: '加入时间',
    key: 'SubTime'
},
                {
        title: 'Action',
    key: 'action',
    width: 150,
    align: 'center',
                    render: (h, params) => {
                        return h('div', [
                            h('Button', {
        props: {
        type: 'primary',
    size: 'small'
},
                                style: {
        marginRight: '5px'
},
                                on: {
        click: () => {
        vtable.show(params.index)
    }
    }
}, '详细信息')
                            ,h('Button', {
        props: {
        type: 'warning',
    size: 'small'
},
                                on: {
        click: () => {
        let index = params.index;
    vtable.formItem.Id = params.row.Id;
    vtable.formItem.UserName = params.row.UName;
    vtable.formItem.selectDep = params.row.DId;
    vtable.formItem.switch = (params.row.DelFlag == 0 ? true : false);
    vtable.getRoleData(params.row.DId, params.row.RId);
}
}
}, '修改')
]);
}
}
],
//表格的数据
data6: [],
//当前登陆账户的信息
ui: [],

//表格分页相关数据
            page: {total: 20, size: 6, current: 1, searchByName: "" },

    //部门和角色下拉框数据
            depAndRole: {
        depData: [],
    roleData:[]
},

//第一行表单  的双向绑定数据
            formItem: {
        Id: 0, switch: false, UserName: "", selectDep: 0, selectRole: 0, submitBtn: {type: "info",value:"添加账户"}}

},
        watch: {
        'formItem.Id': function () {
                if (this.formItem.Id > 0) {
        this.formItem.submitBtn.type = "warning";
    this.formItem.submitBtn.value = "保存修改";
                } else {
        this.cleanformItem();
    }
   
},
            'formItem.selectDep': function () {
        this.formItem.selectRole = "";
    this.depAndRole.roleData = [];
    this.getRoleData(this.formItem.selectDep);
},
},
        methods: {

        addOrEditUser: function () {
                var para = {
        "ID": this.formItem.Id,
    "UName": this.formItem.UserName,
    "DelFlag": (this.formItem.switch ? 0 : 1),
    "DepId": this.formItem.selectDep,
    "RoleId": this.formItem.selectRole
};
var msg="";
                if (para.UName == "") {
        this.$Message.warning("请填写用户姓名");
    return
};
                if (para.RoleId == 0) {
        this.$Message.warning("请为该用户选择角色");
    return
};
                if (para.DepId == 0) {
        this.$Message.warning("请为该用户选择部门");
    return
};
//添加操作
                if (para.ID == 0) {
        this.$http.post("/UserMgr/AddUser", para).then(response => {
            var rst = response.body;
            var id = rst.userinfo.ID
            if (rst.state == 0) {
                this.$Modal.info({
                    title: rst.msg,
                    content: `<h1>新增用户 ${rst.userinfo.UName} 的ID为：${rst.userinfo.ID}</h1>
                                          <h1>初始密码为:${rst.userinfo.UPwd}</h1><br>
                                          <span style="color:brown">*请尽快通知该用户修改密码完善个人信息</span> `,
                });
                this.cleanformItem();
            } else {
                this.$Message.warning(rst.msg);
            }

        }, function () {
            this.$Message.warning("添加失败：请求未被响应");
        });
    };
                if (para.ID != 0) {
        this.$http.post("/UserMgr/EditUser", para).then(response => {
            var rst = response.body;
            if (rst.state == 0) {
                this.cleanformItem();
                this.$Message.success(rst.msg);
            } else {
                this.$Message.warning(rst.msg);
            }


        }, function () {
            this.$Message.warning("修改失败：请求未被响应");
        });
    };
    //修改操作


  
},
            //remove: function (index) {
        //    this.data6.splice(index, 1);
        //},
        getUInfo: function () {
        this.$http.post("/UserMgr/GetUserInfo", this.page).then(response => {
            vtable.page.total = response.body.total;
            vtable.page.current = response.body.current;
            vtable.data6 = response.body.list;

        }, function () {
            this.$Message.warning("获取失败");
        })
    },
            getDepData: function () {
        this.$http.post("/UserMgr/GetDepInfo").then(response => {
            vtable.depAndRole.depData = response.body;
        }, function () {
            alert("请求失败");
        })
    },
            getRoleData: function (DepId,RoleId) {
                var para = {depID: DepId };
                this.$http.post("/UserMgr/GetRoleInfo", para).then(response => {
        vtable.depAndRole.roleData = response.body;
    if (RoleId != undefined) {
        vtable.formItem.selectRole = RoleId;
    }
                }, function () {
        alert("请求失败");
    })
},




            show: function (index) {
        this.$Modal.info({
            title: '员工信息',
            content: `<h1>员工ID:${this.data6[index].Id}</h1>
                    姓名：${this.data6[index].UName}<br>
                    部门：${this.data6[index].DepName}<br>
                    职位：${this.data6[index].RName}<br>
                    LvID:${this.data6[index].Sort}`
        })
    },
            pageChange: function (pageTag) {
        this.page.current = pageTag;
    this.getUInfo();
},
            searchUInfo: function () {
        this.getUInfo();
    },
            cleanformItem: function () {
        this.formItem = {
            Id: 0,
            switch: false,
            UserName: "",
            selectDep: 0,
            selectRole: 0,
            submitBtn: { type: "info", value: "添加账户" }
        };
    }
},
        created: function () {
        //拿到父窗口的 当前用户信息
        //this.ui = window.parent.v.ui;
        this.getUInfo();
    this.getDepData();
}
});


