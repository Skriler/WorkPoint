Vue.component("modal", {
  template: "#modal-template"
});

new Vue({
  el: "#how_it_works",
  data: {
    showModal: false
  }
});

new Vue({
  el: "#spec",
  data: {
    showModal0: false,
    showModal1: false,
    showModal2: false,
    showModal3: false,
    showModal4: false
  }
});

new Vue({
  el: "#about_us",
  data: {
    showModal: false
  }
});
