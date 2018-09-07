Vue.component('receive', {
    template: "#receiveTplt",
    data() {
        return {
            columns: [
                {
                    title: '姓名',
                    key: 'UserInfo.UName',
                    width: 90,
                    render: (h, params) => {
                        return h('div', [
                            h('Icon', {
                                props: {
                                    type: 'person'
                                }
                            }),
                            h('strong', "  " + params.row.UserInfo.UName)
                        ]);
                    }
                },
                {
                    title: '类型',
                    key: 'UserInfo.UName',
                    width: 70,
                    render: (h, params) => {
                        let color;
                        if (params.row.ApplyType.parentId == 1) {
                            color = "#0094ff";
                        } else if (params.row.ApplyType.parentId == 2) {
                            color = "coral";
                        }
                        return h('div', [
                            h('span', {
                                attrs: {
                                    style: `color:${color}`
                                }

                            }, params.row.ApplyType.Name)
                        ])

                    }
                },
                {
                    title: "期限 | 金额",
                    key: 'address',
                    width: 320,
                    render: (h, para) => {
                        let row = para.row;
                        if (row.Number > 0) {
                            return h('div', [
                                h('Icon', {
                                    props: {
                                        type: 'ios-time-outline',
                                        size: 17
                                    }
                                }),
                                h('span', {
                                    attrs: {
                                        style: `font-size:11px;text-align:center`

                                    }

                                }, " " + this.getLocalTime(para.row.BeginDate) + " — " + this.getLocalTime(para.row.EndDate))

                            ])
                        } else if (row.Money > 0) {
                            return h('div', [
                                h('span', {
                                    attrs: {
                                        style: `font-size:17px;text-align:center`
                                    }

                                }, "￥  "),
                                h('span', {
                                    attrs: {
                                        style: `font-size:11px;text-align:center`
                                    }

                                }, para.row.Money),
                            ])
                        }

                    }
                },
                {
                    title: "理由",
                    key: 'Remark1',
                    width: 350,
                    tooltip: true,
                    render: (h, para) => {
                        if (para.row.Money > 0) {
                            return h('div', [
                                h('span', para.row.Remark1),
                                h('a', {
                                    attrs: {
                                        href: `#`
                                    }

                                }, "         查看附件")
                            ])
                        } else {
                            return h('span', para.row.Remark1)

                        }

                    }
                },
                {
                    title: "提交时间",
                    key: 'SubTime',
                    width: 170,
                    render: (h, para) => {
                        return h('span', this.getLocalTime(para.row.SubTime));

                    }

                },
                {
                    title: '操作',
                    key: 'action',

                    align: 'center',
                    render: (h, params) => {

                        if (params.row.State == 1) {
                            return h('span', {
                                attrs: {
                                    style: `font-size:10px;color:blue`
                                }

                            }, "已 同 意")

                        } else if (params.row.State == 0) {
                            return h('span', {
                                attrs: {
                                    style: `font-size:10px;color:red`
                                }

                            }, "已 退 回")
                        } else {
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
                                            this.handle(params.index, true)
                                        }
                                    }
                                }, '同意'),
                                h('Button', {
                                    props: {

                                        type: 'error',
                                        size: 'small'
                                    },
                                    on: {
                                        click: () => {
                                            this.handle(params.index, false)
                                        }
                                    }
                                }, '退回')
                            ]);
                        }
                    }
                }
            ],
            list: [],
            Remark: "",
        }
    },//---------------------------------------------------------------------
    methods: {
        handleApply(ApplyObj, isAgree, Remark, ) {
            const apply = ApplyObj;
            let pars = {
                Id: apply.Id,
                State: isAgree ? 1 : 0,
                ApproverId: apply.ApproverId,
                Remark2: Remark
            };
            this.$http.post("/Apply/HandleApply", pars).then(resp => {
                if (resp.body.state == 0) {
                    this.$Message.success(resp.body.msg);
                    apply.State = pars.State;
                    apply.Remark2 = pars.Remark2;
                } else {
                    this.$Message.error(resp.body.msg);
                }

            }, function () {
                this.$Message.error("请求未发送成功");

            })
            this.Remark = "";
        },
        getDateList() {
            this.$http.post("/Apply/GetReceiveList").then(resp => {
                if (resp.body.state == 0) {
                    this.list = resp.body.list;
                    this.$Message.success(resp.body.msg);
                } else {

                    this.$Message.error(resp.body.msg);
                }


            }, function () {
                this.$Message.error("请求未发送成功");
            })
        },
        handle(index, isAgree) {
            let date = this.list[index];
            let color = isAgree ? "blue" : "#ff6a00";
            let handleType = isAgree ? "同意 " : "退回 ";
            let btnText = isAgree ? " 批准 " : " 退回 ";
            var self = this;
            this.$Modal.confirm({
                okText: btnText,
                draggable: true,
                render: (h) => {
                    return h('div', {
                        attrs: {
                            style: `border-top:8px solid ${color};height:100%`,
                        }

                    }, [
                            h('div', {
                                attrs: {

                                    style: `margin:1% 1% 1% 1%`
                                }
                            }, [
                                    h('br'),
                                    h('h3', {
                                        attrs: {
                                            style: `color:${color}`,
                                        }
                                    }, handleType + date.UserInfo.UName + " 的 " + date.ApplyType.Name + " 申请"),
                                    h('br'),
                                    h('Input', {
                                        props: {
                                            value: self.Remark,
                                            type: `textarea`,
                                            rows: 3,
                                            placeholder: "备注信息(选填)"
                                        },
                                        on: {
                                            input: (val) => {
                                                self.Remark = val;
                                            }
                                        }



                                    })
                                ])
                        ])
                },
                onOk: () => {
                    this.handleApply(date, isAgree, this.Remark)
                }
            })
        },
        getLocalTime(nS) {
            return new Date(nS).toLocaleString().replace(/:\d{1,2}$/, ' ');
        },

    },//---------------------------------------------------------------------
    created() {
        this.getDateList();

    }//---------------------------------------------------------------------
});