<template>
    <div id="app">
        <div class="firstDiv">
            <input type="text" />
            <button>Añadir</button>
        </div>

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
                            :class="{red: task.severity === 'High', yellow: task.severity === 'Medium' , green: task.severity === 'Low'}"></kanban>
                    <!--<div v-for="(task) in column.tasks" :key="task.id"
                         :task="task" 
                         :class="{red: task.severity === 'High', yellow: task.severity === 'Medium' , green: task.severity === 'Low'}">
                        <h1>{{task.title}}</h1>
                    </div>-->
                </div>
            </div>

            <div v-show="currentTab === 1">
                <div class="secondDiv">
                    <div v-for="column in columns"
                         :key="column.title"
                         class="thirdDiv">
                        <h1 class="firstP">{{column.title}}</h1>
                        <!-- Draggable component comes from vuedraggable. It provides drag & drop functionality -->
                        <draggable class="draggable" dir:list="column.tasks" :animation="200" ghost-class="ghost-card" group="tasks">
                            <!-- Each element from here will be draggable and animated. Note :key is very important here to be unique both for draggable and animations to be smooth & consistent. -->
                            <kanban v-for="(task) in column.tasks"
                                    :key="task.id"
                                    :task="task"
                                    class="kanban"></kanban>
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
                                severity: "High"
                            },
                            {
                                id: 2,
                                title: "Provide documentation on integrations",
                                description: "Provide documentation on integrations",
                                severity: "Medium"
                            },
                            {
                                id: 3,
                                title: "Design shopping cart dropdown",
                                description: "Design shopping cart dropdown",
                                severity: "High"
                            },
                            {
                                id: 4,
                                title: "Add discount code to checkout page",
                                description: "Add discount code to checkout page",
                                severity: "Low"

                            },
                            {
                                id: 5,
                                title: "Test checkout flow",
                                description: "Test checkout flow",
                                severity: "Low"
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
                                severity: "Low"
                            },
                            {
                                id: 7,
                                title: "Modify discount to checkout page",
                                description: "Modify discount to checkout page",
                                severity: "Low"
                            },
                            {
                                id: 8,
                                title: "Integrations",
                                description: "Provide documentation on integrations",
                                severity: "Medium"
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
                                severity: "Medium"
                            },
                            {
                                id: 10,
                                title: "Connecting server",
                                description: "Connecting server",
                                severity: "High"
                            },
                            {
                                id: 11,
                                title: "Response from API",
                                description: "Response from API",
                                severity: "High"
                            },
                            {
                                id: 12,
                                title: "Designing LOGO",
                                description: "Designing LOGO",
                                severity: "Low"
                            },
                            {
                                id: 13,
                                title: "Create social networks",
                                description: "Create social networks",
                                severity: "Low"
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
                                severity: "Low"
                            },
                            {
                                id: 15,
                                title: "Store data in DB",
                                description: "Store data in DB",
                                severity: "Medium"
                            },
                            {
                                id: 16,
                                title: "Develop autosave",
                                description: "Develop autosave",
                                severity: "High"
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
            }
        },
        created() {
            this.$http.get('https://jsonplaceholder.typicode.com/users').then(function (data) {
                this.users = data.body.slice(0,10)
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
    }

    .firstP {
        color: rgba(55, 65, 81);
        font-size: 1.5rem;
        font-weight: 600;
        text-align: center;
    }

    .kanban {
        margin-top: 0.75rem;
        cursor: move;
        width: 350px;
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
        padding: 10px;
        margin-top: 20px;
        height: 50px;
    }
    .green {
        background-color: green;
        width: inherit;
        margin-top: 20px;
        height: 50px;
    }
    .yellow {
        background-color: yellow;
        width: inherit;
        margin-top: 20px;
        height: 50px;
    }
</style>
