import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import type { Board } from "../types/boardTypes";
import axios from "axios";
import Column from "../Components/Column";
import Modal from "../Components/Modal";

const Board = () => {
    const [board, setBoard] = useState<Board>()
    const [isModalOpen, setIsModalOpen] = useState(false);
    const { id } = useParams();

    const [columnName, setColumnName] = useState("");

    // Errors
    interface IColumnNameError {errorMessage: string; hasError: boolean; }
    const [columnNameError, setColumnNameError] = useState<IColumnNameError>({errorMessage: "", hasError: false});

    function validateInputs(boardName: string) {
        setColumnNameError({errorMessage: "", hasError: false})
        if (boardName.trim().length == 0) {
            setColumnNameError({errorMessage: "Name cannot be empty", hasError: true})
            return false
        }

        setColumnNameError({errorMessage: "", hasError: false})
        return true;
        
    }

    const getBoard = async () => {
        try {
            const res = await axios.get(`http://localhost:5267/api/boards/${id}`)
            setBoard(res.data)
        } catch (error) {
            console.log(error)
        }
    };

    const createColumn = async () => {
        const isValid = validateInputs(columnName)
        if (!isValid) {
            return;
        }

        try {
            const res = await axios.post(`http://localhost:5267/api/boards/${id}/columns`, {columnName})
            setBoard(prev => {
            if (!prev) return prev;

            return {
                ...prev,
                columns: [...prev.columns, res.data],
                };
            });
            setColumnName("");
            setColumnNameError({
                errorMessage: "",
                hasError: false
            });
            setIsModalOpen(false);
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
                    <Column key={item.id} column={item} onTaskCreated={getBoard}/>
                ))}
                <button
                    onClick={() => setIsModalOpen(true)}
                    className="flex items-center justify-center max-h-full w-80 shrink-0 flex-col rounded-xl p-4 border-3 border-dotted border-gray-400 hover:shadow-sm hover:-translate-y-1 transition-all font-mono select-none cursor-pointer"
                >
                    <p className="text-lg font-bold">New Column +</p>
                </button>
                <Modal isOpen={isModalOpen} OnClose={() => setIsModalOpen(false)}>
                    <div className="flex flex-col gap-4 font-mono">
                        <h1 className="text-lg">Create Column</h1>
                        <div className="flex flex-col gap-2 pl-2 pr-2">
                            <p className="text-md">Column Name</p>
                            <input
                                type="text"
                                value={columnName}
                                onChange={(e) => setColumnName(e.target.value)}
                                className="border border-blue-500 rounded-xl p-3"
                            >
                            </input>
                            {columnNameError.hasError && 
                                <p className="text-sm text-red-400">{columnNameError.errorMessage}</p>
                            }
                            <div className="flex justify-between pt-4">
                                <button 
                                className="p-2 cursor-pointer bg-red-400 hover:bg-red-300 rounded-xl active:translate-y-0.5 active:shadow-lg"
                                onClick={() => {setIsModalOpen(false), setColumnNameError({
                                                                        errorMessage: "",
                                                                        hasError: false
                                                                    });}}
                                >
                                    Cancel
                                </button>
                                <button 
                                className="p-2 cursor-pointer bg-blue-400 hover:bg-blue-300 rounded-xl active:translate-y-0.5 active:shadow-lg"
                                onClick={() => createColumn()}
                                >
                                    Create
                                </button>
                            </div>
                        </div>
                    </div>
                </Modal>
            </div>
        </div>
    );
}

export default Board;