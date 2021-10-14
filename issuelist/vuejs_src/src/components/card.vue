<template>
    <div class="card"
         :class="`bg-${color}-100 text-${color}-700`">
        <span class="textoCard" :class="`bg-${color}-400`"></span>
        <span>
            <slot></slot>
        </span>
    </div>
</template>
<script>
    export default {
        props: {
            color: {
                type: String,
                default: "teal"
            }
        }
    };
</script>
<style scoped>
    .card {
        display: flex;
        border-radius: 9999px;
        background-color: white;
        height: 1.5rem;
        font-size: 0.75rem;
        line-height: 1rem;
        align-items: center;
        font-weight: 600;
        
    }

    .textoCard {
        border-radius: 9999px;
        height: 0.5rem;
        width: 0.5rem;
        margin-right: 0.25rem;
    }
</style>
