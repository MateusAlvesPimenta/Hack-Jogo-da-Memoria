import { api } from "./api";

export function switchCards(path2) {

    console.log(path2)
    let path1 = localStorage.getItem("path");

    if (path1 == null) {
        localStorage.setItem("path", path2);
        return;
    }
    if (path1 === path2) {
        localStorage.removeItem("path");
        return;
    }

    api.put("/SwitchCards", { path1: path1, path2: path2 })
        .then(response => {
            console.log("Switched Successfully" + response.data);
        })
        .catch(e => {
            console.log("Switch failed" + e.response.data);
        });

    localStorage.removeItem("path");
}