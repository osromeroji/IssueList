<template>
    <div id="app">
        
        <div class="tab">
            <button v-for="(tab, index) in tabs" :key="index" @click="currentTab = index" :class="{active: currentTab === index}">{{ tab }}</button>
        </div>

        <div class="tab-content">
            <div v-show="currentTab === 0">
                <div v-for="column in columns"
                     :key="column.title" class="issueList">
                    <kanban v-for="(task) in column.tasks"
                            :key="task.id"
                            :task="task"
                            v-bind:asigneeName="task.asignee"
                            :class="{red: task.severity === 'High', yellow: task.severity === 'Medium' , green: task.severity === 'Low'}">
                    </kanban>
                </div>
            </div>

            <div v-show="currentTab === 1">
                <div class="firstDiv">
                    <input type="text" />
                    <button>Añadir</button>
                </div>

                <div class="secondDiv">
                    <div v-for="column in columns"
                         :key="column.title"
                         class="thirdDiv">
                        <h1 class="firstP">{{column.title}}</h1>
                        <draggable class="draggable" dir:list="column.tasks" :animation="200" ghost-class="ghost-card" group="tasks">
                            <!-- Each element from here will be draggable and animated. Note :key is very important here to be unique both for draggable and animations to be smooth & consistent. -->
                            <kanban v-for="(task) in column.tasks"
                                    :key="task.id"
                                    :task="task"
                                    v-bind:asigneeName="task.asignee"
                                    :class="{kanbanred: task.severity === 'High', kanbanyellow: task.severity === 'Medium' , kanbangreen: task.severity === 'Low'}">
                            </kanban>
                            <!-- </transition-group> -->
                        </draggable>
                    </div>
                </div>
            </div>
        </div> 
    </div>
</template>


<script src="https://unpkg.com/axios/dist/axios.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/vue/2.5.2/vue.min.js"></script>
<script>
    import draggable from "vuedraggable";
    import kanban from "./components/kanban.vue";
    const axios = require('axios');
    var url = '@Url.RouteUrl("Default")';

    export default {
        name: "App",
        components: {
            kanban,
            draggable
        },
        data() {
            return {
                mensaje: 'Hola mundo desde vue',
                currentTab: 0,
                tabs: ['List', 'Kanban'],
                users : [],
                columns: [
                    {
                        title: "Backlog",
                        tasks: [
                            {
                                id: 1,
                                title: "Add discount code to checkout page",
                                description: "Add discount code to checkout page",
                                severity: "High",
                                asignee: ""
                            },
                            {
                                id: 2,
                                title: "Provide documentation on integrations",
                                description: "Provide documentation on integrations",
                                severity: "Medium",
                                asignee: ""
                            },
                            {
                                id: 3,
                                title: "Design shopping cart dropdown",
                                description: "Design shopping cart dropdown",
                                severity: "High",
                                asignee: ""
                            },
                            {
                                id: 4,
                                title: "Add discount code to checkout page",
                                description: "Add discount code to checkout page",
                                severity: "Low",
                                asignee: ""

                            },
                            {
                                id: 5,
                                title: "Test checkout flow",
                                description: "Test checkout flow",
                                severity: "Low",
                                asignee: ""
                            }
                        ]
                    },
                    {
                        title: "To do",
                        tasks: [
                            {
                                id: 6,
                                title: "Design shopping cart web",
                                description: "Design shopping cart web",
                                severity: "Low",
                                asignee: ""
                            },
                            {
                                id: 7,
                                title: "Modify discount to checkout page",
                                description: "Modify discount to checkout page",
                                severity: "Low",
                                asignee: ""
                            },
                            {
                                id: 8,
                                title: "Integrations",
                                description: "Provide documentation on integrations",
                                severity: "Medium",
                                asignee: ""
                            }
                        ]
                    },
                    {
                        title: "Doing",
                        tasks: [
                            {
                                id: 9,
                                title: "Creating app",
                                description: "Creating app",
                                severity: "Medium",
                                asignee: ""
                            },
                            {
                                id: 10,
                                title: "Connecting server",
                                description: "Connecting server",
                                severity: "High",
                                asignee: ""
                            },
                            {
                                id: 11,
                                title: "Response from API",
                                description: "Response from API",
                                severity: "High",
                                asignee: ""
                            },
                            {
                                id: 12,
                                title: "Designing LOGO",
                                description: "Designing LOGO",
                                severity: "Low",
                                asignee: ""
                            },
                            {
                                id: 13,
                                title: "Create social networks",
                                description: "Create social networks",
                                severity: "Low",
                                asignee: ""
                            }
                        ]
                    },
                    {
                        title: "Done",
                        tasks: [
                            {
                                id: 14,
                                title: "Apply styles",
                                description: "Apply styles",
                                severity: "Low",
                                asignee: ""
                            },
                            {
                                id: 15,
                                title: "Store data in DB",
                                description: "Store data in DB",
                                severity: "Medium",
                                asignee: ""
                            },
                            {
                                id: 16,
                                title: "Develop autosave",
                                description: "Develop autosave",
                                severity: "High",
                                asignee: ""
                            }
                        ]
                    }
                ]
            };
        },
        methods: {
            getColorOfCard: function (severity) {
                let color = '';
                if (severity == "High") {
                    color = "red";
                } else if (severity == "Medium") {
                    color = "yellow";
                } else if (severity == "Low") {
                    color = "green";
                }
                return { color };
            },
            fetchData: function (users) {
                this.users = users;
                for (var i = 0; i < this.columns.length; i++) {
                    for (var j = 0; j < this.columns[i].tasks.length; j++) {
                        console.log(this.columns[i].tasks[j].asignee);
                        this.columns[i].tasks[j].asignee = this.users[Math.floor(Math.random() * (9 - 0 + 1)) + 0].name;
                        console.log(this.columns[i].tasks[j].asignee);
                    }
                }
            }
        },
        created() {

            this.$http.get('https://jsonplaceholder.typicode.com/users').then(function (data) {
                this.fetchData(data.body);
            })
        }
    };
</script>

<style scoped>
    .firstDiv {
        padding-top: 10px;
        margin-left: 20px;
        margin-bottom: -1px;
    }

        .firstDiv input {
            width: 250px;
        }

    .draggable {
        text-align: center;
        justify-content: center;
        text-align: center;
    }

    .firstDiv button {
        width: 80px;
    }

    .secondDiv {
        padding-bottom: 3rem;
        display: flex;
        min-height: 100vh;
    }

    .thirdDiv {
        padding-bottom: 3rem;
        padding-left: 0.75rem;
        padding-right: 0.75rem;
        margin: 20px;
        border-radius: 0.5rem;
        background-color: rgb(204,204,255);
        width: 50%;
        justify-content: center;
        align-items: center;
        text-align: center;
    }

    .firstP {
        color: rgba(55, 65, 81);
        font-size: 1.5rem;
        font-weight: 600;
        text-align: center;
    }


    .column-width {
        min-width: 320px;
        width: 320px;
    }
    .issueListElement {
        width: 100%;
    }
    /* Unfortunately @apply cannot be setup in codesandbox,
    but you'd use "@apply border opacity-50 border-blue-500 bg-gray-200" here */
    .ghost-card {
        opacity: 0.5;
        background: #F7FAFC;
        border: 1px solid #4299e1;
    }
    /* Style the tab */
    .tab {
        overflow: hidden;
        border: 1px solid #ccc;
        background-color: #f1f1f1;
    }

        /* Style the buttons that are used to open the tab content */
        .tab button {
            background-color: inherit;
            float: left;
            border: none;
            outline: none;
            cursor: pointer;
            padding: 14px 16px;
            transition: 0.3s;
        }

            /* Change background color of buttons on hover */
            .tab button:hover {
                background-color: #ddd;
            }

            /* Create an active/current tablink class */
            .tab button.active {
                background-color: #ccc;
            }

    /* Style the tab content */
    .tabcontent {
        display: none;
        padding: 6px 12px;
        border: 1px solid #ccc;
        border-top: none;
    }
    .red {
        background-color: red;
        width: inherit;
        margin-top: 20px;
        height: 60px;
    }
    .green {
        background-color: limegreen;
        width: inherit;
        margin-top: 20px;
        height: 60px;
    }
    .yellow {
        background-color: yellow;
        width: inherit;
        margin-top: 20px;
        height: 60px;
    }
    .kanbanred {
        background-color: red;
        width: inherit;
        margin-top: 20px;
        margin-top: 0.75rem;
        cursor: move;
        height: 80px;
    }

    .kanbangreen {
        background-color: limegreen;
        width: inherit;
        margin-top: 20px;
        margin-top: 0.75rem;
        cursor: move;
        height: 80px;
    }

    .kanbanyellow {
        background-color: yellow;
        width: inherit;
        margin-top: 20px;
        margin-top: 0.75rem;
        cursor: move;
        height: 80px;
    }
</style>
