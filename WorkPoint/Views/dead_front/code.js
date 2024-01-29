Vue.component("home", {
    emits: ['next'],
    props: {
        quest: Array,
        i: Number
    },
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
        <a type="button" @click="$emit('next')" class="rect_2">
            <div class="txt">
                <p>Розпочати</p>
            </div>
        </a>
    </div>`
});


Vue.component("quests", {
    emits: ['next', 'prev'],
    props: {
        quest: Array,
        i: Number
    },
    template: `
    <div>
        <div v-for="q in quest">
        <div v-if="q.id === i">
            <div class="main_head">
                <div class="txt">
                    <p>Питання {{ q.id }}:</p>
                    <p>{{ q.text }}</p>
                </div>
                <div class="skills">
                    <div class="row" >
                        <div class="col-4" v-for="(n, m) in q.options">
                            <div class="check">
                                <label>
                                    <div v-if="q.radio_check">
                                        <input  class="radio_button" type="radio" name="radio" :value="m"><span>{{ n }}</span>
                                    </div>
                                    <div v-if="!q.radio_check">
                                        <input type="checkbox" name="check" :value="m""><span>{{ n }}</span>
                                    </div>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="l">
                <a type="button" @click="$emit('prev')" class="rect_3">
                    <div class="txt">
                        <p>Назад</p>
                    </div>
                </a>
            </div>
            <div class="r">
                <a type="button" @click="$emit('next')" class="rect_3">
                    <div class="txt">
                        <p>Далі</p>
                    </div>
                </a>
            </div>
        </div>
        </div>
        </div>
    `
});

Vue.component("results", {
    template: `
    <div class="lists">
        <div class="main_head">
            <div class="txt">
                <p v-for="n in 5">
                    Вакансія № {{n}}
                </p>
            </div>
        </div>
    </div>
    `
});

var app = new Vue({
    el: '#app',
    data: {
    currentTab: "home",
    i: 0,
    quests: [
        {id: 1, text: "На яку заробітню плату ви розраховуєте(тис.грн)?", radio_check: true, options: ["6+", "10+", "20+", "30+", "50+", "100+"]},
        {id: 2, text: "Ви шукаєте роботу дистанційно?", radio_check: true, options: ["Так", "Ні"]},
        {id: 3, text: "Офіс повинен знаходитись у Запоріжжі?", radio_check: true, options: ["Так", "Ні"]},
        {id: 4, text: "Який у вас досвід роботи?", radio_check: true, options: ["<1", "1< і <2", "2< і <3", "3< і <5", "5< і <10", "10+"]},
        {id: 5, text: "Ви маєте вищу освіту?", radio_check: true, options: ["Так", "Ні"]},
        {id: 6, text: "Рівень ангійської вище В2?", radio_check: true, options: ["Так", "Ні"]},
        {id: 7, text: "Вкажіть ваші непрофесійні навички(Soft skills).", radio_check: false, options: ["Робота в команді", "Відповідальність", "Пунктуальність", "Вміння спілкуватись", "Аналітичний", "Бізнес", "Уважний", "Планування", "Швидко навчаюся", "Критичне мислення", "Статистика", "Просування контенту"]},
        {id: 8, text: "Які мови програмування ви знаєте?", radio_check: false, options: [ "HTML", "CSS", "Bootstrap", "PHP", "JS", "React", "NodeJS", "Vue", "Vuex", "RestAPI", "Python", "PyTest", "Mocha", "UnitTesting", "TypeScript", "CPlusPlus","CSharp","DOTNET","HTTP","Dart","Flutter","Swift","OneC","WordPress","PrinciplesOOP","SolidPrinciples","Multithreading"]},
        {id: 9, text: "Оберіть СУБД які вам знайомі.", radio_check: false, options: ["MYSQL", "PostgreSQL", "MongoDB", "Redis", "NoSQL", "Oracle", "MSSQL"]},
        {id: 10, text: "Оберіть програми Microsoft Office, які ви знаєте.", radio_check: false, options: ["Word", "Excel","Access", "Powerpoint"]},
        {id: 11, text: "Оберіть операційні системи з якими Ви можете працювати.", radio_check: false, options: ["Windows", "Mac","Linux"]},
        {id: 12, text: "Оберіть програми візуалізації.", radio_check: false, options: ["VSCO", "Snapseed","Lightroom","Photoshop"]},
        {id: 13, text: "Додаткові навички", radio_check: false, options: ["Git",  "GoogleAnalytics", "FacebookAnalytics", "NetworkProtocols","ComputerNetworks","MaintainingSoftware", "NeatpeakSpider", "Ahrefs"]}
    ],
    },
    
    computed: {
        currentTabComponent: function() {
            if (this.i == 0){
                this.currentTab = "home";
            } else{
                if (this.i == 14){
                    this.currentTab = "results";
                }
                else{
                    this.currentTab = "quests";
                }
            }
            return this.currentTab;
        }
}});

