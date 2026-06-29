import type { ColumnBoard } from "../types/boardTypes";
import TaskCard from "./TaskCard";

interface ColumnProps {
    column: ColumnBoard;
}

const Column = ({ column }: ColumnProps) => {
    return (
        <div className="flex max-h-full w-80 shrink-0 flex-col rounded-lg p-4 border-2 border-blue-400">
            <div className="flex justify-between p-2">
                <div className="flex justify-center items-center">
                    <h1>{column.name}</h1>
                </div>
                <button
                    onClick={() => console.log("hello")}
                    className="text-left rounded-xl flex h-full justify-center items-center px-2 gap-1 hover:bg-blue-400 active:translate-y-0.5 active:shadow-lg hover:text-white transition-all font-mono select-none cursor-pointer"
                >
                    <p className="text-lg font-bold">+</p>
                </button>
            </div>
            {column.tasks.map((item) => (
                <TaskCard key={item.id} task={item} />
            ))}
        </div>
    );
}

export default Column