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
    el: "#about_us",
    data: {
      showModal: false
    }
  });