Vue.component('initiate', {
    template: '#initiateTplt',

    data() {
        return {
            dateList: [],
            isLeave: true,
        }
    },//---------------------------------------------------------------------
    methods: {
        getInitiateList() {
            this.$http.post("/Apply/GetInitiateList").then(resp => {
                if (resp.body.state == 0) {
                    this.dateList = resp.body.list;
                    this.$Message.success(resp.body.msg);
                } else {
                    this.$Message.error(resp.body.msg);
                }

            }, function () {
                this.$Message.success("请求失败");
            })

        },
        annul(Id) {
            alert(Id)

        }
    },///---------------------------------------------------------------------
    filters: {
        Step3States(state) {
            if (state == 2) {
                return 'wait'
            } else if (state == 0) {

                return 'error'
            } else if (state == 1) {

                return 'finish'
            }

        },
        Step2States(state) {
            if (state == 2) {
                return 'process'
            } else if (state == 3) {
                return 'error'
            } else if (state < 2) {
                return 'finish'

            }

        },
        Step3Content(state, index, name, remark) {
            if (state > 1) {
                return '······'
            } else if (state == 0) {

                return '您的申请已被【' + name + '】退回！备注消息:' + remark
            } else if (state == 1) {

                return '【' + name + '】已同意您的申请！ 备注消息:' + remark
            }

        },
        Step2Content(state, applyObj) {
            if (state == 2) {
                return '等待【' + applyObj.UserInfo1.UName + '】的审批'
            } else if (state < 2) {
                return '【' + applyObj.UserInfo1.UName + '】已经审批'
            } else if (state == 3) {
                return '您已经撤销了此申请'
            }
        },
        getLocalTime(nS) {
            return new Date(nS).toLocaleString().replace(/:\d{1,2}$/, ' ');
        }

    },///---------------------------------------------------------------------
    created() {
        this.getInitiateList();

    },///---------------------------------------------------------------------

});