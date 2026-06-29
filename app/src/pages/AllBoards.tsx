import axios from "axios";
import { useEffect, useState } from "react";
import type { BoardCardData } from "../types/boardTypes";
import BoardCard from "../Components/BoardCard";
import Modal from "../Components/Modal";

const AllBoards = () => {
    const [boards, setBoards] = useState<BoardCardData[]>([]);
    const [isModalOpen, setIsModalOpen] = useState(false);

    const [boardName, setBoardName] = useState("");

    // Errors
    interface IBoardNameError {errorMessage: string; hasError: boolean; }
    const [boardNameError, setBoardNameError] = useState<IBoardNameError>({errorMessage: "", hasError: false});

    function validateInputs(boardName: string) {
        setBoardNameError({errorMessage: "", hasError: false})
        if (boardName.trim().length == 0) {
            setBoardNameError({errorMessage: "Name cannot be empty", hasError: true})
            return false
        }

        setBoardNameError({errorMessage: "", hasError: false})
        return true;
        
    }

    const getBoards = async () => {
        try {
            const res = await axios.get("http://localhost:5267/api/boards");
            setBoards(res.data);
        } catch (error) {
            console.log(error);
        }
    };

    const createBoard = async () => {
        const isValid = validateInputs(boardName)
        if (!isValid) {
            return;
        }

        try {
            const res = await axios.post("http://localhost:5267/api/boards", {boardName})
            setBoards(prev => [...prev, res.data]);
            setBoardName("");
            setBoardNameError({
                errorMessage: "",
                hasError: false
            });
            setIsModalOpen(false);
        } catch (error) {
            console.log(error)
        }

    }

    useEffect(() => {
        getBoards();
    }, []);

    return (
        <>
            <div className="w-full grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-3 p-3">
                {boards.map((item) => (
                    <BoardCard key={item.id} board={item} />
                ))}
                <button
                    onClick={() => setIsModalOpen(true)}
                    className="w-full text-left p-3 rounded-xl flex h-full justify-center items-center gap-1 border-3 border-dotted border-gray-400 hover:-translate-y-1 hover:shadow-sm transition-all font-mono select-none cursor-pointer"
                >
                    <p className="text-lg font-bold">New Board +</p>
                </button>
                <Modal isOpen={isModalOpen} OnClose={() => {setIsModalOpen(false), setBoardNameError({
                                                                        errorMessage: "",
                                                                        hasError: false
                                                                    });}}>
                    <div className="flex flex-col gap-4 font-mono">
                        <h1 className="text-lg">Create board</h1>
                        <div className="flex flex-col gap-2 pl-2 pr-2">
                            <p className="text-md">Board Name</p>
                            <input
                                type="text"
                                value={boardName}
                                onChange={(e) => setBoardName(e.target.value)}
                                className="border border-blue-500 rounded-xl p-3"
                            >
                            </input>
                            {boardNameError.hasError && 
                                <p className="text-sm text-red-400">{boardNameError.errorMessage}</p>
                            }
                            <div className="flex justify-between pt-4">
                                <button 
                                className="p-2 cursor-pointer bg-red-400 hover:bg-red-300 rounded-xl active:translate-y-0.5 active:shadow-lg"
                                onClick={() => {setIsModalOpen(false), setBoardNameError({
                                                                        errorMessage: "",
                                                                        hasError: false
                                                                    });}}
                                >
                                    Cancel
                                </button>
                                <button 
                                className="p-2 cursor-pointer bg-blue-400 hover:bg-blue-300 rounded-xl active:translate-y-0.5 active:shadow-lg"
                                onClick={() => createBoard()}
                                >
                                    Create
                                </button>
                            </div>
                        </div>
                    </div>
                </Modal>
            </div>
        </>
    );
}

export default AllBoards;