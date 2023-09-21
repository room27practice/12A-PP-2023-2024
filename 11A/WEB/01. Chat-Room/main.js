"use strict";
function solve(a) {
    // alert('zapochvame' + a);
    debugger;
    let typing = document.getElementById("typing2");
    typing.style.display = "none";
    let submitBtn = document.querySelector("#send");
    // let sameButton = document.getElementById("send");
    // let test = document.querySelector("div.chat-box-header>h3");


    let targetContainer = document.getElementById("chat_messages");
    let contentElement = document.getElementById("chat_input");

    if (submitBtn === null || targetContainer === null || contentElement === null) {
        throw new Error("element Not found");
    }

    submitBtn.addEventListener("click", CreateNewMessageElement);

    function CreateNewMessageElement(event, somethingElse, somethingAnother) {
        debugger

        if (!contentElement.value) {
            alert("You are trying to submit empty messages!!!!")
            return;
        }
        let newMessageElement = document.createElement("div");
        newMessageElement.classList.add("message", "my-message");
        newMessageElement.textContent = contentElement.value;

        const textValue = contentElement.value;
        newMessageElement.addEventListener(`click`, function (evt) {
            alert("Removed: " + textValue);
            targetContainer.removeChild(newMessageElement);
        })


        targetContainer.appendChild(newMessageElement);
        contentElement.value = "";
    }


    contentElement.addEventListener("keypress", function (event) {
        console.log(event);

        if (typing !== null) {
            typing.style.display = "block";
            let milisecondsToWait = 1500;
            function hideAgain() {
                typing.style.display = "none";
            };
            setTimeout(hideAgain, milisecondsToWait);
        }
    });

}