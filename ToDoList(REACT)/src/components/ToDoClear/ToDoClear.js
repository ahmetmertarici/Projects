import { useContext } from "react";
import { ItemContext } from "../../contexts/ItemContext";

function ToDoClear() {
    const context = useContext(ItemContext);
    const clearCompleted = () => context.setListe(context.liste.filter(item => !item.tamamlandi));
    return (
        <button onClick={() => { clearCompleted() }} className="temizle">
            Tamamlananları Temizle
        </button>
    )
}

export default ToDoClear;