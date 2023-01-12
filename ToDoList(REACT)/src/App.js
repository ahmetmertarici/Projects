import ToDoContainer from "./components/ToDoContainer/ToDoContainer";

const INITIAL_STATE = [
  { id: 1, baslik: 'Alışveriş yap', tamamlandi: false },
  { id: 2, baslik: 'Kitabı bitir', tamamlandi: false },
  { id: 3, baslik: 'Gibi yeni bölümü kaçırma', tamamlandi: true }
]

function App() {
  return (
      <div className="App">
        <ToDoContainer tasks={INITIAL_STATE}/>
      </div>
  );
}
export default App;
