import { api } from "./api";

export function deleteCards() {

    api.delete("/DeleteCards")
        .then(response => {
            console.log("Deleted successfully " + response.data);
        })
        .catch(e => {
            console.log("Deletion failed " + e.response.data);
        });
}