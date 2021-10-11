<template>
    <div class="mainDiv">
        <div class="secondDiv">
            <p class="firstP">{{task.title}}</p>

            <img class="firstImage"
                 src="https://pickaface.net/gallery/avatar/unr_sample_161118_2054_ynlrg.png"
                 alt="Avatar">
        </div>
        <div class="thirdDiv">
            <span class="firstSpan">{{task.date}}</span>
            <card v-if="task.type" :color="cardColor">{{task.type}}</card>
        </div>
    </div>
</template>
<script>
import card from './card.vue'
export default {
  components: {
    card
  },
  props: {
    task: {
      type: Object,
      default: () => ({})
    }
  },
  computed: {
    cardColor() {
      const mappings = {
        Design: "purple",
        "Feature Request": "teal",
        Backend: "blue",
        QA: "green",
        default: "teal"
      };
      return mappings[this.task.type] || mappings.default;
    }
  }
};
</script>
<style scoped>
    .mainDiv {
        box-shadow: 0 0 5px 5px #666;
        border-color: white;
        border-style: solid;
        border-width: 0.2px;
        padding-bottom: 5px;
        padding-top: 3px;
        padding-left: 0.75rem;
        padding-right: 0.75rem;
        background-color: gray;
        width: 350px;
        border-radius: 5px;
    }

    .secondDiv {
        justify-content: space-between;
        background-color: red;
    }

    .thirdDiv {
        display: flex;
        align-items: center;
        justify-content: space between;
        margin-top: 1rem;
    }

    .firstP {
        font-size: 0.875rem;
        line-height: 1.25rem;
        letter-spacing: 0.025em;
        font-weight: 600;
        color: rgba(55, 65, 81);
    }

    .firstImage {
        width: 1.5rem;
        height: 1.5rem;
        margin-left: 0.75rem;
        border-radius: 9999px;
    }

    .firstSpan {
        color: rgba(75, 85, 99);
        font-size: 0.875rem;
        line-height: 1.25rem;
    }
</style>
