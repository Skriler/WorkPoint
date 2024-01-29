Vue.component("home", {
    template: `
    <div>
        <div class="main_head">
            <div class="txt">
                <div class="row">
                    <div class="col-4"><div class="mhd"><div class="r">Work</div></div></div>
                    <div class="col-4"><div class="eclipse"></div></div>
                    <div class="col-4"><div class="mhd"><div class="l">Point</div></div></div>
                </div>
                Твоя точка відліку
            </div>
        </div>
        <a type="button" v-bind:key='quests' v-on:click="currentTab = 'quests'" class="rect_2">
            <div class="txt">
                <p>Розпочати</p>
            </div>
        </a>
    </div>`
});


//далее checkbox может чередоваться с radio : <input class="radio_button" type="radio" name="radio" value="{{ (n-1)*6+m }}"><span>скилл № {{ (n-1)*6+m }}</span>
Vue.component("quests", {
    template: `
        <div>
            <div class="main_head">
                <div class="txt">
                    <p>Питання 1:</p>
                    <p>Якими скілами ви володієте?</p>
                </div>
                <div class="skills">
                    <div class="row" v-for="n in 3">
                        <div class="col-3" v-for="m in 4">
                            <div class="check">
                                <label>
                                    <input type="checkbox" value="1"><span>скилл № {{ (n-1)*6+m }}</span>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="l">
                <a type="button" class="rect_3">
                    <div class="txt">
                        <p>Назад</p>
                    </div>
                </a>
            </div>
            <div class="r">
                <a type="button" class="rect_3">
                    <div class="txt">
                        <p>Далі</p>
                    </div>
                </a>
            </div>
        </div>
    `
});

Vue.component("results", {
    template: `
    <div>
        <div class="main_head">
            <div class="txt">
                <p v-for="n in 5">Вакансія № {{ n }}</p>
                <br>
                <p>Ці вакансії найліпше вам підходять за вказаними навичками:</p>
                <br>
                <p v-for="n in 5">Скілл № {{ n }}</p>
            </div>
        </div>
    </div>
    `
});

new Vue({
    el: '#app',
    data: {
    currentTab: "Home",
    tabs: ["home", "quests", "results"]
    },
    computed: {
        currentTabComponent: function() {
            return this.currentTab;
        }
}})