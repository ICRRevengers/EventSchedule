import Wrapper from '../defaultLayout/wrapper/Wrapper';

const Sidebar = ({ company, jobs }) => {
    return (
        <>
            <Wrapper
                className="bg-[#000050] h-[100vh] w-[300px] text-[#fff]"
                content="p-[20px]"
            ></Wrapper>
            <div className="fixed text-[#fff] w-[300px]   mx-[auto]   p-[20px]">
                <div className="font-bold text-[20px] text-center mb-[20px]">
                    {company}
                </div>
                <h1 className="border-b border-[#ffffff86]"></h1>
                {jobs &&
                    jobs.map((job, index) => (
                        <div className="mb-[10px]" key={index}>
                            {index}. {job}
                        </div>
                    ))}
            </div>
        </>
    );
};

export default Sidebar;
