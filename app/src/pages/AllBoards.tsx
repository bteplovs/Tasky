import axios from "axios";
import { useEffect, useState } from "react";
import type { BoardCardData } from "../types/boardTypes";
import BoardCard from "../Components/BoardCard";

const AllBoards = () => {
    const [boards, setBoards] = useState<BoardCardData[]>([]);

    const getBoards = async () => {
        try {
            const res = await axios.get("http://localhost:5267/api/boards");
            setBoards(res.data);
        } catch (error) {
            console.log(error);
        }
    };

    useEffect(() => {
        getBoards();
    }, []);

    return (
        <>
            <div className="w-full grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-3 p-3">
                {boards.map((item) => (
                    <BoardCard board={item} />
                ))}
                <button
                    onClick={() => console.log("Create board")}
                    className="w-full text-left p-3 rounded-xl flex h-full justify-center items-center gap-1 border-3 border-dotted border-gray-400 hover:-translate-y-1 hover:shadow-sm transition-all font-mono select-none cursor-pointer"
                >
                    <p className="text-lg font-bold">New Board +</p>
                </button>
            </div>
        </>
    );
}

export default AllBoards;