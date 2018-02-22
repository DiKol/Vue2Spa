import ToDoData from 'components/to-do'
import HomePage from 'components/home-page'

export const routes = [
    { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
    { name: 'todo', path: '/todo', component: ToDoData, display: 'Manage To Do', icon: 'list' }
]
