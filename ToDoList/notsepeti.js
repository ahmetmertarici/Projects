const newTask = document.querySelector(".input-task");
const newTaskBtn = document.querySelector(".btn-task-add");
const taskList = document.querySelector(".task-list");

newTaskBtn.addEventListener("click", function (e) {
    let value = newTask.value;
    if (value.length > 0) {
        addNewTask(value);
        saveLocalStorage(value);
        value = "";
        newTask.focus();
    } else {
        alert("Job description cannot be left blank!")
    }
});


function saveLocalStorage(task) {
    let tasks = convertToArray();
    tasks.push(task);
    localStorage.setItem("tasks", JSON.stringify(tasks));
}
function convertToArray() {
    let tasks;
    if (localStorage.getItem("tasks") === null) {
        tasks = [];
    } else {
        tasks = JSON.parse(localStorage.getItem("tasks"));
    }
    return tasks;
}
getLocalStorage();
function getLocalStorage() {
    let tasks = convertToArray();
    tasks.forEach(function (task) {
        addNewTask(task);
    });
}
taskList.addEventListener("click", function (e) {
    const clickedElement = e.target;
    if (clickedElement.classList.contains("task-btn-ok")) {
        clickedElement.parentElement.classList.toggle("task-ok");
    }
    if (clickedElement.classList.contains("task-btn-del")) {
        if (confirm("Are you sure you want to delete?")) {
            const deleteTask = clickedElement.parentElement.children[0].innerText;
            clickedElement.parentElement.remove();
            removeFromLocalStorage(deleteTask);
        }
    }
});

function removeFromLocalStorage(task) {
    let tasks = convertToArray();
    const indexDeletedTask = tasks.indexOf(task);
    tasks.splice(indexDeletedTask, 1);
    localStorage.setItem("tasks", JSON.stringify(tasks));
}

function addNewTask(inputValue) {
    const taskDiv = document.createElement("div");
    taskDiv.classList.add("task-item");

    const taskLi = document.createElement("li");
    taskLi.classList.add("task-description");
    taskLi.innerText = inputValue;
    taskDiv.appendChild(taskLi);

    const taskBtnOk = document.createElement("button");
    taskBtnOk.classList.add("task-btn");
    taskBtnOk.classList.add("task-btn-ok");
    taskBtnOk.innerHTML = '<i class="fa-solid fa-square-check"></i>';
    taskDiv.appendChild(taskBtnOk);

    const taskBtnDel = document.createElement("button");
    taskBtnDel.classList.add("task-btn");
    taskBtnDel.classList.add("task-btn-del");
    taskBtnDel.innerHTML = '<i class="fa-solid fa-trash-can">';
    taskDiv.appendChild(taskBtnDel);

    taskList.appendChild(taskDiv);
}



