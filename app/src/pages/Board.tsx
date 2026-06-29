import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import type { Board } from "../types/boardTypes";
import axios from "axios";
import Column from "../Components/Column";

const Board = () => {
    const [board, setBoard] = useState<Board>()
    const { id } = useParams();

    const getBoard = async () => {
        try {
            const res = await axios.get(`http://localhost:5267/api/boards/${id}`)
            setBoard(res.data)
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(() => {
        getBoard();
    }, [])

    return (
        <div className="flex h-screen flex-col overflow-hidden p-6 font-mono">
            <h1 className="text-lg">{board?.name}</h1>

            <div className="flex flex-1 gap-4 overflow-x-auto overflow-y-hidden pt-4">
                {board?.columns.map((item) => (
                    <Column key={item.id} column={item} />
                ))}
                <button
                    onClick={() => console.log("Hello")}
                    className="flex items-center justify-center max-h-full w-80 shrink-0 flex-col rounded-xl p-4 border-3 border-dotted border-gray-400 hover:shadow-sm hover:-translate-y-1 transition-all font-mono select-none cursor-pointer"
                >
                    <p className="text-lg font-bold">New Column +</p>
                </button>
            </div>
        </div>
    );
}

export default Board;