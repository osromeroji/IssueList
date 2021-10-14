<template>
    <div contenteditable="true" v-once v-html="value" :value="value" @input="$emit('input', $event.target.innetHTML)">
    </div>
</template>
<script>
    export default {
        props: ['value'],
        watch: {
            value: function (newValue) {
                if (document.activeElement == this.$el) {
                    return;
                }
                this.$el.innerHTML = newValue;
            }
        }
    };
</script>

