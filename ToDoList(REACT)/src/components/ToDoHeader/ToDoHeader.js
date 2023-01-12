import { useContext } from "react";
import { ItemContext } from "../../contexts/ItemContext";
function ToDoHeader() {
    const context = useContext(ItemContext);
    const addNew = (title) => {
        context.setListe([...context.liste, { id: Date.now(), baslik: title, tamamlandi: false }]);
        context.setYeniBaslik('');
    }
    return (
        <>
            <h1>Yapılacaklar Listesi</h1>
            <div className="ekleme_formu">
                <input onChange={(e) => context.setYeniBaslik(e.target.value)} type="text" value={context.yeniBaslik} placeholder="Yeni başlık ekle..." />
                <button
                    onClick={() => { addNew(context.yeniBaslik) }}
                >Ekle</button>
            </div>
        </>
    )
}

export default ToDoHeader;