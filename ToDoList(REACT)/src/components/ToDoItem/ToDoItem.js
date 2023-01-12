import React, { useContext } from 'react'
import { MdDelete, MdCheckCircle, MdCheckCircleOutline } from 'react-icons/md';
import { ItemContext } from '../../contexts/ItemContext';
function ToDoItem({ item }) {
    const context = useContext(ItemContext);
    const clearItem = (id) => context.setListe(
        context.liste.filter(item => item.id != id));
    const markCompleted = id => context.setListe(context.liste.map(i => i.id == id ? { ...i, tamamlandi: !i.tamamlandi } : i));
    return (
        <div className="toDoItem">
            <div
                key={item.id}
                className={item.tamamlandi ? "yapildi" : ""}
                style={{ textAlign: 'left' }}
            >
                {item.baslik}
            </div>
            <div>
                <button className="btn btn-completed" onClick={() => {
                    markCompleted(item.id)
                }}>{item.tamamlandi ? <MdCheckCircleOutline color='white' /> : <MdCheckCircle color='white' />}</button>
                <button className="btn btn-delete"><MdDelete color='white' onClick={
                    () => {
                        clearItem(item.id)
                    }
                } /></button>
            </div>
        </div>
    )
}

export default ToDoItem