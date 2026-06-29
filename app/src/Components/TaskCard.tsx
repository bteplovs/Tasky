import type { TaskBoard } from "../types/boardTypes";

interface TaskCardProps {
    task: TaskBoard;
}

const TaskCard = ({ task }: TaskCardProps) => {
    return (
        <div className="font-mono w-full text-left p-3 rounded-xl flex flex-col gap-1 bg-blue-400">
            <h1 className="text-lg">{task.title}</h1>
        </div>
    )
}

export default TaskCard