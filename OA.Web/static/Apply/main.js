var _Main = new Vue({
    el: "#app",
    data: {
        initiateMsgCount: 0,
        receiveMsgCount: 0,
        initiateMsg: (h) => {
            return h('div', [
                h('span', '  我的申请  '),
                h('Badge', {
                    props: {
                        count: _Main.initiateMsgCount,
                    }
                })
            ])
        },
        receiveMsg: (h) => {
            return h('div', [
                h('span', '   待我审批  '),
                h('Badge', {
                    props: {
                        count: _Main.receiveMsgCount
                    }

                })

            ])
        }

    },
    methods: {
        loadMsgCount() {
            this.$http.post("/Apply/GetTabTips").then(resp => {
                if (resp.body.state == 0) {
                    _Main.initiateMsgCount = resp.body.initiateMsgCount;
                    _Main.receiveMsgCount = resp.body.receiveMsgCount;
                    _Main.$Message.info(resp.body.msg)
                } else {
                    this.$Message.error("未获取数据")

                }
            }, function () {
                this.$Message.error("请求失败")

            })

        },

    },
    created() {
        this.loadMsgCount();

    }

})