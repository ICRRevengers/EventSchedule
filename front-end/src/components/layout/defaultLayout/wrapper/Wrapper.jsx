const Wrapper = ({ className, content, children }) => {
    //props
    return (
        <div className={className}>
            <div
                className={'max-w-[1350px] box-content ' + content}
                style={{
                    position: 'relative',
                    left: '50%',
                    transform: 'translateX(-50%)',
                }}
            >
                {children}
            </div>
        </div>
    );
};

// //<Wrapper>
//     childrend
// </Wrapper>
export default Wrapper;
