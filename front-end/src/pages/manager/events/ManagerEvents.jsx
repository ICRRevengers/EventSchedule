import Sidebar from '../../../components/layout/sidebar/Sidebar';
import { FiEdit3 } from 'react-icons/fi';
import Button from '../../../components/button/Button';

const ManagerEvents = () => (
    <div className="flex">
        <Sidebar />
        <div className="grow h-[100vh] bg-[#FBFBFF] p-[40px] ">
            <h1 className="text-[20px] font-medium flex items-center mb-[20px]">
                Create jobs in &nbsp;<strong>$$$</strong>
                <FiEdit3 className="ml-[15px] cursor-pointer" />
            </h1>
            <div className="bg-[#fff] border-[2px] flex relative">
                <div className="h-[100%] w-[75%] border-r-[2px] p-[20px] flex flex-col">
                    <div className="flex justify-between">
                        <Button className="font-semibold">View Request</Button>
                        <div className="text-right font-medium">
                            Rate: 3.7
                            <br />
                            Comment: 123
                            <br />
                            Request Candidate: 123
                        </div>
                    </div>
                    <div className="text-[24px] pt-[30px] pb-[15px] border-b font-medium flex items-center">
                        JAVA WEB DEVELOPMENT
                        <FiEdit3 className="ml-[15px] cursor-pointer" />
                    </div>
                    <div className="py-[10px] font-semibold text-[16px] flex flex-col ">
                        <span className="py-[5px] flex items-center">
                            Categories:{' '}
                            <FiEdit3 className="ml-[15px] cursor-pointer" />
                        </span>
                        <span className="py-[5px] flex items-center ">
                            Categories:{' '}
                            <FiEdit3 className="ml-[15px] cursor-pointer" />
                        </span>
                        <span className="py-[5px] flex items-center">
                            Categories:{' '}
                            <FiEdit3 className="ml-[15px] cursor-pointer" />
                        </span>
                    </div>
                    <div className="h-[450px] border py-[10px] px-[20px]   relative">
                        <div className="text-[#000070] absolute w-fit cursor-pointer right-[20px] font-medium underline underline-offset-1 italic">
                            Edit
                        </div>
                        <div className="overflow-auto h-[100%] w-[100%] pt-[20px]">
                            <div>a</div>
                            <div>a</div>
                            <div>a</div>
                        </div>
                    </div>
                    <div className="flex items-center pt-[40px] justify-around">
                        <Button>Delete</Button>
                        <Button>Save</Button>
                    </div>
                </div>
                <div className="grow flex ">
                    <Button className="m-[auto] text-[16px] w-[175px] ">
                        Import Image
                    </Button>
                </div>
            </div>
        </div>
    </div>
);

export default ManagerEvents;
