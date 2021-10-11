<template>
    <div id="app">
        <div class="firstDiv">
            <input type="text" />
            <button>Añadir</button>
        </div>
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
</template>

<script>
    import draggable from "vuedraggable";
    import kanban from "./components/kanban.vue";
    export default {
        name: "App",
        components: {
            kanban,
            draggable
        },
        data() {
            return {
                columns: [
                    {
                        title: "Backlog",
                        tasks: [
                            {
                                title: "Add discount code to checkout page",
                                description: "",
                                severity: ""
                            },
                            {
                                id: 2,
                                title: "Provide documentation on integrations",
                                date: "Sep 12"
                            },
                            {
                                id: 3,
                                title: "Design shopping cart dropdown",
                                date: "Sep 9",
                                type: "Design"
                            },
                            {
                                id: 4,
                                title: "Add discount code to checkout page",
                                date: "Sep 14",
                                type: "Feature Request"
                            },
                            {
                                id: 5,
                                title: "Test checkout flow",
                                date: "Sep 15",
                                type: "QA"
                            }
                        ]
                    },
                    {
                        title: "In Progress",
                        tasks: [
                            {
                                id: 6,
                                title: "Design shopping cart dropdown",
                                date: "Sep 9",
                                type: "Design"
                            },
                            {
                                id: 7,
                                title: "Add discount code to checkout page",
                                date: "Sep 14",
                                type: "Feature Request"
                            },
                            {
                                id: 8,
                                title: "Provide documentation on integrations",
                                date: "Sep 12",
                                type: "Backend"
                            }
                        ]
                    },
                    {
                        title: "Review",
                        tasks: [
                            {
                                id: 9,
                                title: "Provide documentation on integrations",
                                date: "Sep 12"
                            },
                            {
                                id: 10,
                                title: "Design shopping cart dropdown",
                                date: "Sep 9",
                                type: "Design"
                            },
                            {
                                id: 11,
                                title: "Add discount code to checkout page",
                                date: "Sep 14",
                                type: "Feature Request"
                            },
                            {
                                id: 12,
                                title: "Design shopping cart dropdown",
                                date: "Sep 9",
                                type: "Design"
                            },
                            {
                                id: 13,
                                title: "Add discount code to checkout page",
                                date: "Sep 14",
                                type: "Feature Request"
                            }
                        ]
                    },
                    {
                        title: "Done",
                        tasks: [
                            {
                                id: 14,
                                title: "Add discount code to checkout page",
                                date: "Sep 14",
                                type: "Feature Request"
                            },
                            {
                                id: 15,
                                title: "Design shopping cart dropdown",
                                date: "Sep 9",
                                type: "Design"
                            },
                            {
                                id: 16,
                                title: "Add discount code to checkout page",
                                date: "Sep 14",
                                type: "Feature Request"
                            }
                        ]
                    }
                ]
            };
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
        /* Unfortunately @apply cannot be setup in codesandbox,
    but you'd use "@apply border opacity-50 border-blue-500 bg-gray-200" here */
        .ghost-card {
            opacity: 0.5;
            background: #F7FAFC;
            border: 1px solid #4299e1;
        }
</style>
