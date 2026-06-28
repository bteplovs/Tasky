import { useNavigate } from "react-router-dom";
import type { BoardCardData } from "../types/boardTypes";

interface BoardCardProps {
    board: BoardCardData;
}

const BoardCard = ({ board }: BoardCardProps) => {
    const navigate = useNavigate();
    return (
        <button
            onClick={() => navigate(`/boards/${board.id}`)}
            className="w-full text-left p-3 rounded-xl flex flex-col gap-1 bg-blue-300 hover:-translate-y-1 hover:shadow-sm transition-all font-mono select-none cursor-pointer"
        >
            <p className="text-lg font-bold">{board.name}</p>
            <p className="text-md">{board.numTasks} Tasks</p>
        </button>
    )
}

export default BoardCard