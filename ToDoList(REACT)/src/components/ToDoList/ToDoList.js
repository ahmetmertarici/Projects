import { useContext } from "react";
import ToDoItem from "../ToDoItem/ToDoItem";
import { ItemContext } from "../../contexts/ItemContext";
function ToDoList() {
    const context = useContext(ItemContext);
    return (
        <div className="liste">
            {
                context.liste.map(item => (
                    <ToDoItem item={item} />
                ))
            }
        </div>
    )
}

export default ToDoList;