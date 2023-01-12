import React, { useState } from "react";
import ToDoHeader from "../ToDoHeader/ToDoHeader";
import ToDoList from "../ToDoList/ToDoList";
import ToDoClear from "../ToDoClear/ToDoClear";
import { ItemContext } from "../../contexts/ItemContext";

function ToDoContainer({ tasks }) {
    const [liste, setListe] = useState(tasks);
    const [yeniBaslik, setYeniBaslik] = useState('');

    return (
        <ItemContext.Provider value={{ liste, setListe, yeniBaslik, setYeniBaslik }}>
            <ToDoHeader />
            <ToDoList />
            <ToDoClear />
        </ItemContext.Provider>
    )
}
export default ToDoContainer;