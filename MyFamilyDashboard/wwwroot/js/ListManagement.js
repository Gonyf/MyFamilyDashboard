// Create a "close" button and append it to each list item
var myNodelist = document.getElementsByTagName("LI");
var i;
for (i = 0; i < myNodelist.length; i++) {
    var span = document.createElement("SPAN");
    var txt = document.createTextNode("\u00D7");
    span.className = "close";
    span.id = "todoItem" + i;
    span.appendChild(txt);
    myNodelist[i].appendChild(span);
}

function OnClick() {
    var div = this.parentElement;
    var input = this.parentElement.getElementsByTagName("input");
    var input = input[0];
    //console.log(input);
    input.value = null;
    div.style.display = "none";
}
// Click on a close button to hide the current list item
var close = document.getElementsByClassName("close");
var i;
for (i = 0; i < close.length; i++) {
    close[i].onclick = OnClick;
}

// Add a "checked" symbol when clicking on a list item
var list = document.getElementById('todoList');
list.addEventListener('click', function (ev) {
    if (ev.target.tagName === 'LI') {
        ev.target.classList.toggle('checked');
        //console.log(ev.target.querySelector('.completed'));
        var completed = ev.target.querySelector('.completed')
        if (completed.value == "False") {
            completed.value = "True";
        }
        else {
            completed.value = "False";
        }
    }
}, false);

// Create a new list item when clicking on the "Add" button
function newElement() {
    var input = document.createElement("input")
    var li = document.createElement("li");
    li.appendChild(input);
    var list = document.getElementById('todoList');
    var itemNumber = list.childElementCount;
    input.setAttribute("name", "TodoItems[" + (itemNumber - 1) + "].Text");
    input.id = "TodoItems_" + (itemNumber - 1) + "__Text";

    var inputValue = document.getElementById("myInput").value;
    input.value = inputValue;
    if (inputValue === '') {
        alert("You must write something!");
    } else {
        document.getElementById("todoList").appendChild(li);
    }
    document.getElementById("myInput").value = "";

    var span = document.createElement("SPAN");
    var txt = document.createTextNode("\u00D7");
    span.className = "close";
    span.appendChild(txt);
    li.appendChild(span);

    for (i = 0; i < close.length; i++) {
        close[i].onclick = OnClick;
    }
}